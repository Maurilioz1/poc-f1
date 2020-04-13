using FluentValidation;

namespace POCF1.Business.Models.Validations
{
    public class CorridaValidation : AbstractValidator<Corrida>
    {
        public CorridaValidation()
        {
            RuleFor(e => e.NomeCircuito)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .MaximumLength(30).WithMessage("O campo {PropertyName} deve ter no máximo 30 caracteres.");
        }
    }
}
