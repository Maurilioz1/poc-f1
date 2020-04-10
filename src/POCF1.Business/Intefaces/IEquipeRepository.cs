using POCF1.Business.Models;
using System.Threading.Tasks;

namespace POCF1.Business.Intefaces
{
    public interface IEquipeRepository : IRepository<Equipe>
    {
        Task<Equipe> ObterEquipePilotos(int id);
    }
}
