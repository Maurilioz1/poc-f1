using POCF1.Business.Interfaces;
using POCF1.Business.Models;
using POCF1.Data.Context;

namespace POCF1.Data.Repository
{
    public class CorridaRepository : Repository<Corrida>, ICorridaRepository
    {
        public CorridaRepository(ApiDbContext context) : base(context) { }
    }
}
