using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Uni.Academic.Shared.Requests.Couses;

namespace Uni.Academic.Web.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : AcademicControllerBase
    {
        public CoursesController(IMediator mediator)
            : base(mediator) { }

        [HttpPost]
        public Task<IActionResult> Register([FromBody]RegisterCourseRequest request)
            => SendCommand(request);
    }
}
