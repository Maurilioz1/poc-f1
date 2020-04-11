using Microsoft.EntityFrameworkCore;
using POCF1.Business.Interfaces;
using POCF1.Business.Models;
using POCF1.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCF1.Data.Repository
{
    public class PilotoRepository : Repository<Piloto>, IPilotoRepository
    {
        public PilotoRepository(ApiDbContext context) : base(context) { }

        public async Task<Piloto> ObterPilotoEquipe(int id)
        {
            return await Db.Pilotos.AsNoTracking().Include(f => f.Equipe)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Piloto>> ObterPilotosEquipes()
        {
            return await Db.Pilotos.AsNoTracking().Include(f => f.Equipe)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Piloto>> ObterPilotosPorEquipe(int equipeId)
        {
            return await Buscar(p => p.EquipeId == equipeId);
        }
    }
}
