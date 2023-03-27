using Application.AppModel;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Commands.Create
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public override ValidationResult Validate(ValidationContext<CreateOrderCommand> context)
        {
            RuleFor(x => x.OrderPrice)
                .NotEmpty().WithMessage("Cena nie moze byc zerowa")
                .GreaterThan(3).WithMessage("Za niska cena");

            RuleFor(x => x.CreateDate)
                .LessThan(DateTime.Now)
                .WithMessage("Nieprawidlowa data zamowienia");

            RuleFor(x => x.ClientName)
                .MinimumLength(3).WithMessage("Za krotka nazwa klienta");

            var valueOfProducts = context.InstanceToValidate.OrderLines.Sum(x => x.Price);

            RuleFor(x => x.OrderPrice)
                .Equal(valueOfProducts).WithMessage("Rozsynchronizowana wartosc zamowienia");


            RuleForEach(x => x.OrderLines).SetValidator(new OrderLineDtoValidator());

            return base.Validate(context);
        }
    }
}