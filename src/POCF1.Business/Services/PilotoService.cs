using POCF1.Business.Intefaces;
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

        public async Task Adicionar(Piloto piloto)
        {
            if (!ExecutarValidacao(new PilotoValidation(), piloto)) return;

            await _pilotoRepository.Adicionar(piloto);
        }

        public async Task Atualizar(Piloto piloto)
        {
            if (!ExecutarValidacao(new PilotoValidation(), piloto)) return;

            await _pilotoRepository.Atualizar(piloto);
        }

        public async Task Remover(int id)
        {
            await _pilotoRepository.Remover(id);
        }

        public void Dispose()
        {
            _pilotoRepository?.Dispose();
        }
    }
}
