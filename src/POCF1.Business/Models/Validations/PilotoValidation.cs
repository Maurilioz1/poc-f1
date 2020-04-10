using FluentValidation;

namespace POCF1.Business.Models.Validations
{
    public class PilotoValidation : AbstractValidator<Piloto>
    {
        public PilotoValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .MaximumLength(50).WithMessage("O campo {PropertyName} deve ter no máximo 50 caracteres.");

            RuleFor(c => c.EquipeId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.NivelExperiencia)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .InclusiveBetween(1, 5).WithMessage("O campo {PropertyName} precisa ter um valor entre 1 e 5.");

            RuleFor(c => c.QuantidadeParadas)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .InclusiveBetween(1, 3).WithMessage("O campo {PropertyName} precisa ter um valor entre 1 e 3.");

            RuleFor(c => c.PosicaoLargada)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .InclusiveBetween(1, 20).WithMessage("O campo {PropertyName} precisa ter um valor entre 1 e 20.");
        }
    }
}
