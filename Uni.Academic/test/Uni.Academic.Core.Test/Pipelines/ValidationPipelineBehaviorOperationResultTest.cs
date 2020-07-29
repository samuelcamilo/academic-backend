using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Uni.Academic.Core.RequestHandlers.Pipelines;
using Uni.Academic.Shared;
using Xunit;

namespace Uni.Academic.Core.Test.Pipelines
{
    public class ValidationPipelineBehaviorOperationResultTest
    {
        private readonly AbstractValidator<SampleRequest> _validator;
        private readonly IPipelineBehavior<SampleRequest, OperationResult> _sut;

        public ValidationPipelineBehaviorOperationResultTest()
        {
            _validator = new SampleRequestValidator();
            _sut = new ValidationPipelineBehavior<SampleRequest, OperationResult>(_validator);
        }

        [Fact]
        public async Task WhenModelContainsErrorShouldReturnOperationResultWithError()
        {
            // Arrange...
            SampleRequest request = new SampleRequest();

            // Act...
            var (success, exception) = await _sut.Handle(request, CancellationToken.None, null);

            // Assert...
            Assert.False(success);
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task WhenModelContainsSuccessShouldReturnOperationResultWithSuccess()
        {
            // Arrange...
            SampleRequest request = new SampleRequest { Name = "Not Null Property" };

            static Task<OperationResult> Next() => Task.FromResult(OperationResult.Success());

            // Act...
            var (success, exception) = await _sut.Handle(request, CancellationToken.None, Next);

            // Assert...
            Assert.True(success);
            Assert.Null(exception);
        }
    }

    public class SampleRequest : IRequest<OperationResult>, IValidatable
    {
        public string Name { get; set; }
    }

    public class SampleRequestValidator : AbstractValidator<SampleRequest>
    {
        public SampleRequestValidator()
            => RuleFor(x => x.Name).NotNull();
    }
}
