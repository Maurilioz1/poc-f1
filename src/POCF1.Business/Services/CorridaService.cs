using POCF1.Business.Interfaces;
using POCF1.Business.Models;
using POCF1.Business.Models.Validations;
using System.Threading.Tasks;

namespace POCF1.Business.Services
{
    public class CorridaService : BaseService, ICorridaService
    {
        private readonly ICorridaRepository _corridaRepository;

        public CorridaService(ICorridaRepository corridaRepository, INotificador notificador) : base(notificador)
        {
            _corridaRepository = corridaRepository;
        }

        public async Task<bool> Adicionar(Corrida corrida)
        {
            if (!ExecutarValidacao(new CorridaValidation(), corrida)) return false;

            await _corridaRepository.Adicionar(corrida);
            return true;
        }

        public async Task<bool> Atualizar(Corrida corrida)
        {
            if (!ExecutarValidacao(new CorridaValidation(), corrida)) return false;

            await _corridaRepository.Atualizar(corrida);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _corridaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _corridaRepository?.Dispose();
        }        
    }
}
