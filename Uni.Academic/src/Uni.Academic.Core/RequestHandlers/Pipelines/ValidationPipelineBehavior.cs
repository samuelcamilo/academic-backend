using FluentValidation;
using MediatR;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Uni.Academic.Shared;
using Uni.Academic.Shared.Exceptions;

namespace Uni.Academic.Core.RequestHandlers.Pipelines
{
    public sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IValidatable
    {
        private readonly AbstractValidator<TRequest> _validator;
        private readonly MethodInfo _operationResultError;
        private readonly Type _type = typeof(TRequest);
        private readonly Type _typeOperationResult = typeof(OperationResult);
        private readonly Type _typeOperationResultGeneric = typeof(OperationResult<>);

        public ValidationPipelineBehavior(AbstractValidator<TRequest> validator)
        {
            this._validator = validator;
            if(_type.IsGenericType)
            {
                _operationResultError = _typeOperationResult.GetMethods().FirstOrDefault(m => m.Name == "Error" && m.IsGenericMethod);
                _operationResultError = _operationResultError.MakeGenericMethod(_type.GetGenericArguments().First());
            }
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationResult = _validator.Validate(request);
            if (validationResult.IsValid)
                return next.Invoke();

            var errors = validationResult.Errors.GroupBy(v => v.PropertyName, v => v.ErrorMessage).ToDictionary(v => v.Key, v => v.Select(y => y));
            if (_type == _typeOperationResult)
            {
                var operationResult = OperationResult.Error(new AcademicValidationFailedException(errors));
                return Task.FromResult((TResponse)Convert.ChangeType(operationResult, _type));
            }

            if (!_type.IsGenericType || _type.GetGenericTypeDefinition() != _typeOperationResultGeneric)
                return next.Invoke();

            var validationError = new AcademicValidationFailedException(errors);
            return Task.FromResult((TResponse)Convert.ChangeType(_operationResultError.Invoke(null, new object[] { validationError }), _type));
        }
    }
}
