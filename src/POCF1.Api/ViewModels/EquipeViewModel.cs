using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POCF1.Api.ViewModels
{
    public class EquipeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(600, 700, ErrorMessage = "O campo {0} precisa ter um valor entre {1} e {2}.")]
        public int PotenciaCarro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, 5, ErrorMessage = "O campo {0} precisa ter um valor entre {1} e {2}.")]
        public int AerodinamicaCarro { get; set; }
    }
}
