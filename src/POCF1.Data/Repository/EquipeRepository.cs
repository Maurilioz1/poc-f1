using Microsoft.EntityFrameworkCore;
using POCF1.Business.Interfaces;
using POCF1.Business.Models;
using POCF1.Data.Context;
using System.Threading.Tasks;

namespace POCF1.Data.Repository
{
    public class EquipeRepository : Repository<Equipe>, IEquipeRepository
    {
        public EquipeRepository(ApiDbContext context) : base(context) { }

        public async Task<Equipe> ObterEquipe(int id)
        {
            return await Db.Equipes.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Equipe> ObterEquipePilotos(int id)
        {
            return await Db.Equipes.AsNoTracking()
                .Include(c => c.Pilotos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
