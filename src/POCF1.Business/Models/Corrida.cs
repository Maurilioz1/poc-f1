using System;
using System.Collections.Generic;

namespace POCF1.Business.Models
{
    public class Corrida : Entity
    {
        public string NomeCircuito { get; set; }
        public int TrajetoTotalCircuito { get; set; }
        public DateTime DataCorrida { get; set; }
        public int? Piloto1Id { get; set; }
        public Piloto Piloto1 { get; set; }
        public TimeSpan? Tempo1 { get; set; }
        public int? Piloto2Id { get; set; }
        public Piloto Piloto2 { get; set; }
        public TimeSpan? Tempo2 { get; set; }
        public int? Piloto3Id { get; set; }
        public Piloto Piloto3 { get; set; }
        public TimeSpan? Tempo3 { get; set; }
    }
}
