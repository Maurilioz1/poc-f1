using POCF1.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POCF1.Business.Interfaces
{
    public interface IPilotoRepository : IRepository<Piloto>
    {
        Task<IEnumerable<Piloto>> ObterPilotosPorEquipe(int equipeId);
        Task<IEnumerable<Piloto>> ObterPilotosEquipes();
        Task<Piloto> ObterPilotoEquipe(int id);
    }
}
