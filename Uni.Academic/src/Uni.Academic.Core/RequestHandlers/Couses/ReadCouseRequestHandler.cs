using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Uni.Academic.Core.Interfaces.Repositories;
using Uni.Academic.Shared;
using Uni.Academic.Shared.Exceptions;
using Uni.Academic.Shared.Requests.Couses;
using Uni.Academic.Shared.ViewModels;

namespace Uni.Academic.Core.RequestHandlers.Couses
{
    class ReadCouseRequestHandler : IRequestHandler<GetCourseRequest, OperationResult<CourseViewModel>>
    {
        private readonly IRepositoryCourse _repositoryCourse;

        public ReadCouseRequestHandler(IRepositoryCourse repositoryCourse)
            => this._repositoryCourse = repositoryCourse;

        public Task<OperationResult<CourseViewModel>> Handle(GetCourseRequest request, CancellationToken cancellationToken)
        {
            var course = _repositoryCourse.GetProjected<CourseViewModel>(request.Id);

            return course is null
                ? OperationResult.Error<CourseViewModel>(new NotFoundException("Course")).AsTask
                : OperationResult.Success(course).AsTask;
        }
    }
}
