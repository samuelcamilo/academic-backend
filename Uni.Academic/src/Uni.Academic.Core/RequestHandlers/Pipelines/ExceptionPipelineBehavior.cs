using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Uni.Academic.Shared;
using static System.Text.Json.JsonSerializer;

namespace Uni.Academic.Core.RequestHandlers.Pipelines
{
    public sealed class ExceptionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Type _type = typeof(TResponse);
        private readonly Type _typeOperationResult = typeof(OperationResult);
        private readonly MethodInfo _operationResultError;
        private readonly ILogger<ExceptionPipelineBehavior<TRequest, TResponse>> _logger;

        public ExceptionPipelineBehavior(ILogger<ExceptionPipelineBehavior<TRequest, TResponse>> logger)
        {
            if(_type.IsGenericType)
            {
                _operationResultError = _typeOperationResult.GetMethods().FirstOrDefault(m => m.Name == "Error" && m.IsGenericMethod);
                _operationResultError = _operationResultError.MakeGenericMethod(_type.GetGenericArguments().First());
            }

            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var eventId = new EventId();

            try
            {
                _logger.LogInformation(eventId, $"Handling request of type {typeof(TRequest).FullName} with data: {Serialize(request)}");
                return await next?.Invoke();

            }catch(Exception e)
            {
                _logger.LogError(eventId, e, "Error on request handling");
                return _type == _typeOperationResult
                    ? (TResponse)Convert.ChangeType(OperationResult.Error(e), _type)
                    : (TResponse)Convert.ChangeType(_operationResultError.Invoke(null, new object[] { e }), _type);
            }
        }
    }
}
