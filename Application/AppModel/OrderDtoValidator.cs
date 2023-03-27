using FluentValidation;
using FluentValidation.Results;

namespace Application.AppModel
{

    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public override ValidationResult Validate(ValidationContext<OrderDto> context)
        {

            RuleFor(x => x.OrderPrice)
                    .NotEmpty().WithMessage("Cena nie moze byc zerowa")
                    .LessThanOrEqualTo(3).WithMessage("Za niska cena");

            return base.Validate(context);
        }
    }
}
