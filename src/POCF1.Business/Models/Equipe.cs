using System.Collections.Generic;

namespace POCF1.Business.Models
{
    public class Equipe : Entity
    {
        public string Nome { get; set; }
        public int PotenciaCarro { get; set; }
        public int AerodinamicaCarro { get; set; }

        public ICollection<Piloto> Pilotos { get; set; }
    }
}
