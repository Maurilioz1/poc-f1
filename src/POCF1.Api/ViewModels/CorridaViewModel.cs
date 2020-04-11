using System;
using System.ComponentModel.DataAnnotations;

namespace POCF1.Api.ViewModels
{
    public class CorridaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter {1} caracteres.")]
        public string NomeCircuito { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(250, 350, ErrorMessage = "O campo {0} precisa ter um valor entre {1} e {2}.")]
        public int TrajetoTotalCircuito { get; set; }

        public DateTime DataCorrida { get; set; }

        public int Piloto1 { get; set; }

        public DateTime Tempo1 { get; set; }

        public int Piloto2 { get; set; }

        public DateTime Tempo2 { get; set; }

        public int Piloto3 { get; set; }

        public DateTime Tempo3 { get; set; }
    }
}
