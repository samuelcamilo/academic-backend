using MediatR;

namespace Uni.Academic.Shared.Requests.Couses
{
    public sealed class RegisterCouseRequest : IRequest<OperationResult>, IValidatable
    {
        public string Description { get; set; }
        public string Resume { get; set; }
    }
}
