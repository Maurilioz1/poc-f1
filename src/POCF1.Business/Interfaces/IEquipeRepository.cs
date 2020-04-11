using POCF1.Business.Models;
using System.Threading.Tasks;

namespace POCF1.Business.Interfaces
{
    public interface IEquipeRepository : IRepository<Equipe>
    {
        Task<Equipe> ObterEquipePilotos(int id);
    }
}
