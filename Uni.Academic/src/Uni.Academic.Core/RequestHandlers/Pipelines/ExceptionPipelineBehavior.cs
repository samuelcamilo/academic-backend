using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Uni.Academic.Core.RequestHandlers.Pipelines
{
    public sealed class ExceptionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            throw new NotImplementedException();
        }
    }
}
