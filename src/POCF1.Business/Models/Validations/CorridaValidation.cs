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

            RuleFor(e => e.TrajetoTotalCircuito)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .InclusiveBetween(250, 350).WithMessage("O campo {PropertyName} precisa ter um valor entre 250 e 350.");
        }
    }
}
