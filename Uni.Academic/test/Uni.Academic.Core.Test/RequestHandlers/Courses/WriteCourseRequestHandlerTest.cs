using Microsoft.VisualBasic;
using NSubstitute;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Uni.Academic.Core.Interfaces.Repositories;
using Uni.Academic.Core.Models;
using Uni.Academic.Core.RequestHandlers.Couses;
using Uni.Academic.Shared.Requests.Couses;
using Xunit;

namespace Uni.Academic.Core.Test.RequestHandlers.Courses
{
    public class WriteCourseRequestHandlerTest
    {
        private readonly IRepositoryCourse _repositoryCourse;
        private readonly WriteCourseRequestHandler _sut;

        public WriteCourseRequestHandlerTest()
        {
            _repositoryCourse = Substitute.For<IRepositoryCourse>();
            _sut = new WriteCourseRequestHandler(_repositoryCourse);
        }

        [Fact]
        public async Task ShouldInsertCourseWhenCallRegiterCourseRequestHandler()
        {
            // arrange...
            var request = CreateRegisterCourseRequest();

            // act...
            var result = await _sut.Handle(request, CancellationToken.None);

            //assert...
            _repositoryCourse.Received().Insert(Arg.Is<Course>(c => CompareValues(c, request)));
        }

        private static RegisterCourseRequest CreateRegisterCourseRequest()
        {
            return new RegisterCourseRequest
            {
                Description = "Description",
                Resume = "Resume",
                Subjects = (new long[] { })
            };
        }

        private static bool CompareValues(Course c, RegisterCourseRequest req)
        {
            var hasSameDescription = c.Description == req.Description;
            var hasSameResume = c.Resume == req.Resume;
            var hasSameSubjects = c.CourseSubjects.Count == req.Subjects.Count();

            return hasSameDescription && hasSameResume && hasSameSubjects;
        }
    }
}
