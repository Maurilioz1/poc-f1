using System.ComponentModel.DataAnnotations;

namespace POCF1.Api.ViewModels
{
    public class PilotoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int EquipeId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, 5, ErrorMessage = "O campo {0} precisa ter um valor entre {1} e {2}.")]
        public int NivelExperiencia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, 3, ErrorMessage = "O campo {0} precisa ter um valor entre {1} e {2}.")]
        public int QuantidadeParadas { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, 20, ErrorMessage = "O campo {0} precisa ter um valor entre {1} e {2}.")]
        public int PosicaoLargada { get; set; }

        public EquipeViewModel Equipe { get; set; }
    }
}
