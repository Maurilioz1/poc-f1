namespace POCF1.Business.Models
{
    public class Piloto : Entity
    {
        public string Nome { get; set; }
        public int EquipeId { get; set; }
        public int NivelExperiencia { get; set; }
        public int QuantidadeParadas { get; set; }
        public int PosicaoLargada { get; set; }

        public Equipe Equipe { get; set; }
    }
}
