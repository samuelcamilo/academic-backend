using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Uni.Academic.Core.RequestHandlers.Pipelines;
using Uni.Academic.Shared;
using Xunit;

namespace Uni.Academic.Core.Test.Pipelines
{
    public class ValidationPipelineBehaviorOperationResultGenericTest
    {
        private readonly AbstractValidator<SampleGenericRequest> _validator;
        private readonly ValidationPipelineBehavior<SampleGenericRequest, OperationResult<long>> _sut;

        public ValidationPipelineBehaviorOperationResultGenericTest()
        {
            _validator = new SampleGenericRequestValidator();
            _sut = new ValidationPipelineBehavior<SampleGenericRequest, OperationResult<long>>(_validator);
        }

        [Fact]
        public async Task WhenModelContainsErrorsShouldReturnOperationResultGenericWithError()
        {
            // Arrange...
            var request = new SampleGenericRequest();

            // Act...
            var (success, result, exception) = await _sut.Handle(request, CancellationToken.None, null);

            // Assert...
            Assert.False(success);
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task WhenModelContainsSuccessShouldReturnOperationResultGenericWithSuccess()
        {
            // Arrange...
            var request = new SampleGenericRequest { Name = "Not Empty" };

            static Task<OperationResult<long>> Next() => Task.FromResult(OperationResult.Success(1L));

            // Act...
            var (success, result, exception) = await _sut.Handle(request, CancellationToken.None, Next);

            Assert.True(success);
            Assert.Null(exception);
            Assert.NotEqual(0, result);
        }
    }

    public class SampleGenericRequest : IRequest<OperationResult<long>>, IValidatable
    {
        public string Name { get; set; }
    }

    public class SampleGenericRequestValidator : AbstractValidator<SampleGenericRequest>
    {
        public SampleGenericRequestValidator() =>
            RuleFor(x => x.Name)
                .NotEmpty();
    }
}
