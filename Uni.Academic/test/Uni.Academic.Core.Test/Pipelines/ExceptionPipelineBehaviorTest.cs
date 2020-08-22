using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;
using Uni.Academic.Core.RequestHandlers.Pipelines;
using Uni.Academic.Shared;
using Xunit;

namespace Uni.Academic.Core.Test.Pipelines
{
    public class ExceptionPipelineBehaviorTest
    {
        private readonly ILogger<ExceptionPipelineBehavior<SampleGenericRequest, OperationResult<long>>> _logger;
        private readonly ExceptionPipelineBehavior<SampleGenericRequest, OperationResult<long>> _sut;

        public ExceptionPipelineBehaviorTest()
        {
            _logger = Substitute.For<ILogger<ExceptionPipelineBehavior<SampleGenericRequest, OperationResult<long>>>>();
            _sut = new ExceptionPipelineBehavior<SampleGenericRequest, OperationResult<long>>(_logger);
        }

        [Fact]
        public async Task WhenHandlerThrowsAnExceptionPipelineConvertToOperationResultWithError()
        {
            // Arrange...
            var exception = new Exception("fail...");
            Task<OperationResult<long>> Next() => throw exception;

            // Act...
            var result = await _sut.Handle(null, CancellationToken.None, Next);

            // Assert...
            var msg = $"Handling request of type {typeof(SampleGenericRequest).FullName} with data: null";
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task WhenHandlerDoesNotThrowsAnExceptionPipeline()
        {
            // Arrange...
            static Task<OperationResult<long>> Next() => Task.FromResult(OperationResult.Success(1L));

            // Act...
            var result = await _sut.Handle(null, CancellationToken.None, Next);

            // Assert...
            Assert.True(result.IsSuccess);
            Assert.Equal(1L, result.Result);
        }
    }
}
