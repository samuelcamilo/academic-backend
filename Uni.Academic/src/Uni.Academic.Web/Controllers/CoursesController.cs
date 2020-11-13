using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Uni.Academic.Shared.Requests.Couses;
using Uni.Academic.Shared.ViewModels;

namespace Uni.Academic.Web.Controllers
{
    [Route("api/v1/courses")]
    public class CoursesController : AcademicControllerBase
    {
        public CoursesController(IMediator mediator)
            : base(mediator) { }

        [HttpGet("{Id}")]
        [ProducesResponseType(404)]
        public Task<ActionResult<CourseViewModel>> GetById(GetCourseRequest request)
            => SendCommand(request);

        [HttpPost]
        public Task<IActionResult> Register([FromBody]RegisterCourseRequest request)
            => SendCommand(request);
    }
}
