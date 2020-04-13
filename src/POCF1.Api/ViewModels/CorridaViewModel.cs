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

        public int TrajetoTotalCircuito { get; set; }

        public DateTime DataCorrida { get; set; }

        public int? Piloto1Id { get; set; }

        public TimeSpan? Tempo1 { get; set; }

        public int? Piloto2Id { get; set; }

        public TimeSpan? Tempo2 { get; set; }

        public int? Piloto3Id { get; set; }

        public TimeSpan? Tempo3 { get; set; }
    }
}
