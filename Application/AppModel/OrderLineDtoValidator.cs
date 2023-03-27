using FluentValidation;
using FluentValidation.Results;

namespace Application.AppModel
{
    public class OrderLineDtoValidator : AbstractValidator<OrderLineDto>
    {
        public override ValidationResult Validate(ValidationContext<OrderLineDto> context)
        {
            RuleFor(x => x.Product).NotEmpty().WithMessage("Zamowienie bez produktow nie moze istniec");

            return base.Validate(context);
        }
    }
}