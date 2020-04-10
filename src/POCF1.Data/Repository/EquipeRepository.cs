using Microsoft.EntityFrameworkCore;
using POCF1.Business.Intefaces;
using POCF1.Business.Models;
using POCF1.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POCF1.Data.Repository
{
    public class EquipeRepository : Repository<Equipe>, IEquipeRepository
    {
        public EquipeRepository(ApiDbContext context) : base(context) { }

        public async Task<Equipe> ObterEquipePilotos(int id)
        {
            return await Db.Equipes.AsNoTracking()
                .Include(c => c.Pilotos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
