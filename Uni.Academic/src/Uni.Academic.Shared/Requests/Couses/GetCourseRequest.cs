using MediatR;
using Microsoft.AspNetCore.Mvc;
using Uni.Academic.Shared.ViewModels;

namespace Uni.Academic.Shared.Requests.Couses
{
    public sealed class GetCourseRequest : IRequest<OperationResult<CourseViewModel>>
    {
        [FromRoute]
        public long Id { get; set; }
    }
}
