using Application.AppModel;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Commands.Update
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public override ValidationResult Validate(ValidationContext<UpdateOrderCommand> context) {
            RuleFor(x => x.Status).NotEqual(Domain.Model.OrderStatus.New).WithMessage("Nie mozesz edytowac realizowanego zamowienia");

            RuleForEach(x => x.OrderLines).SetValidator(new OrderLineDtoValidator());

            return base.Validate(context);
        }
    }
}
