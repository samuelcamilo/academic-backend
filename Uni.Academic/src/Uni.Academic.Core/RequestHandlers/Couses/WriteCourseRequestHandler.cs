using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Uni.Academic.Core.Interfaces.Repositories;
using Uni.Academic.Core.Models;
using Uni.Academic.Shared;
using Uni.Academic.Shared.Exceptions;
using Uni.Academic.Shared.Requests.Couses;
using static Uni.Academic.Shared.OperationResult;

namespace Uni.Academic.Core.RequestHandlers.Couses
{
    public class WriteCourseRequestHandler : IRequestHandler<RegisterCourseRequest, OperationResult>
    {
        private readonly IRepositoryCourse _repositoryCourse;

        public WriteCourseRequestHandler(IRepositoryCourse repositoryCourse)
            => _repositoryCourse = repositoryCourse;

        public Task<OperationResult> Handle(RegisterCourseRequest request, CancellationToken cancellationToken)
        {
            if (_repositoryCourse.ExistsCourse(request.Description))
                throw new NameAlreadyExistsException();

            var newCourse = new Course(request.Description, request.Resume);

            if (request.Subjects?.Any() == true)
                newCourse.AddSubjectsIds(request.Subjects);

            _repositoryCourse.Insert(newCourse);

            return Success().AsTask;
        }
    }
}
