using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Uni.Academic.Core.Interfaces.Repositories;
using Uni.Academic.Shared;
using Uni.Academic.Shared.Exceptions;
using Uni.Academic.Shared.Requests.Couses;
using static Uni.Academic.Shared.OperationResult;

namespace Uni.Academic.Core.RequestHandlers.Couses
{
    public class WriteCourseRequestHandler : IRequestHandler<RegisterCourseRequest, OperationResult>
    {
        private readonly IRepositoryCourse _repoCourse;

        public WriteCourseRequestHandler(IRepositoryCourse repoCourse)
            => _repoCourse = repoCourse;

        public Task<OperationResult> Handle(RegisterCourseRequest request, CancellationToken cancellationToken)
        {
            if (_repoCourse.ExistsCourse(request.Description))
                return Error(new NameAlreadyExistsException()).AsTask;

            // TODO...

            return Success().AsTask;
        }
    }
}
