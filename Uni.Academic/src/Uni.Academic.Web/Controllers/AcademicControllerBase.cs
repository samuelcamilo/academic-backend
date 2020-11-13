using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Uni.Academic.Shared;
using Uni.Academic.Shared.Exceptions;

namespace Uni.Academic.Web.Controllers
{
    public abstract class AcademicControllerBase : ControllerBase
    {
        protected IMediator Mediator { get; }

        public AcademicControllerBase(IMediator mediator)
            => Mediator = mediator;

        protected async Task<ActionResult<T>> SendCommand<T>(IRequest<OperationResult<T>> request, int statusCode = 200)
        {
            return await Mediator.Send(request).ConfigureAwait(false) switch
            {
                (true, var result, _) => StatusCode(statusCode, result),
                var (_, _, error) => HandlerError(error)
            };
        }

        protected async Task<IActionResult> SendCommand(IRequest<OperationResult> request, int statusCode = 200)
        {
            return await Mediator.Send(request).ConfigureAwait(false) switch
            {
                (true, _) => StatusCode(statusCode),
                var (_, error) => HandlerError(error)
            };
        }

        protected ActionResult HandlerError(Exception error)
            => error switch
            {
                AcademicValidationFailedException e => BadRequest(e.Errors),
                NameAlreadyExistsException e => Conflict(e.ExistingId),
                NotFoundException e => NotFound(e.Message),
                _ => BadRequest(new ErrorMessage(error.Message))
            };

        public class ErrorMessage
        {
            public ErrorMessage(string message) => Message = message;

            public string Message { get; }
        }
    }
}
