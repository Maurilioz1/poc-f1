using System;

namespace POCF1.Business.Models
{
    public class Corrida : Entity
    {
        public string NomeCircuito { get; set; }
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
