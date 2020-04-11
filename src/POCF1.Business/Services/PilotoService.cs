using POCF1.Business.Interfaces;
using POCF1.Business.Models;
using POCF1.Business.Models.Validations;
using System.Threading.Tasks;

namespace POCF1.Business.Services
{
    public class PilotoService : BaseService, IPilotoService
    {
        private readonly IPilotoRepository _pilotoRepository;

        public PilotoService(IPilotoRepository pilotoRepository, INotificador notificador) : base(notificador)
        {
            _pilotoRepository = pilotoRepository;
        }

        public async Task<bool> Adicionar(Piloto piloto)
        {
            if (!ExecutarValidacao(new PilotoValidation(), piloto)) return false;

            await _pilotoRepository.Adicionar(piloto);
            return true;
        }

        public async Task<bool> Atualizar(Piloto piloto)
        {
            if (!ExecutarValidacao(new PilotoValidation(), piloto)) return false;

            await _pilotoRepository.Atualizar(piloto);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _pilotoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _pilotoRepository?.Dispose();
        }
    }
}
