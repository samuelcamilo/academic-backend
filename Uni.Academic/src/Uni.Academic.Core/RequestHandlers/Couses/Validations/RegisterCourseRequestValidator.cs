using FluentValidation;
using Uni.Academic.Core.Validations;
using Uni.Academic.Shared.Requests.Couses;

namespace Uni.Academic.Core.RequestHandlers.Couses.Validations
{
    public class RegisterCourseRequestValidator : AbstractValidator<RegisterCourseRequest>
    {
        public RegisterCourseRequestValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithErrorCode(ValidationErrorCode.RequiredErrorCode)
                .MaximumLength(100).WithErrorCode(ValidationErrorCode.MaxValueErrorCode);

            RuleFor(x => x.Resume)
                .NotEmpty().WithErrorCode(ValidationErrorCode.RequiredErrorCode)
                .MaximumLength(500).WithErrorCode(ValidationErrorCode.MaxValueErrorCode);
        }
    }
}
