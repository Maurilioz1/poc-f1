using FluentValidation;

namespace POCF1.Business.Models.Validations
{
    public class EquipeValidation : AbstractValidator<Equipe>
    {
        public EquipeValidation()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .MaximumLength(30).WithMessage("O campo {PropertyName} deve ter no máximo 30 caracteres.");

            RuleFor(e => e.PotenciaCarro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .InclusiveBetween(600, 700).WithMessage("O campo {PropertyName} precisa ter um valor entre 600 e 700.");

            RuleFor(e => e.AerodinamicaCarro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .InclusiveBetween(1, 5).WithMessage("O campo {PropertyName} precisa ter um valor entre 1 e 5.");
        }
    }
}
