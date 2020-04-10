using POCF1.Business.Intefaces;
using POCF1.Business.Models;
using POCF1.Business.Models.Validations;
using System.Linq;
using System.Threading.Tasks;

namespace POCF1.Business.Services
{
    public class EquipeService : BaseService, IEquipeService
    {
        private readonly IEquipeRepository _equipeRepository;

        public EquipeService(IEquipeRepository equipeRepository, INotificador notificador) : base(notificador)
        {
            _equipeRepository = equipeRepository;
        }

        public async Task Adicionar(Equipe equipe)
        {
            if (!ExecutarValidacao(new EquipeValidation(), equipe)) return;

            await _equipeRepository.Adicionar(equipe);
        }

        public async Task Atualizar(Equipe equipe)
        {
            if (!ExecutarValidacao(new EquipeValidation(), equipe)) return;

            await _equipeRepository.Atualizar(equipe);
        }

        public async Task Remover(int id)
        {
            if (_equipeRepository.ObterEquipePilotos(id).Result.Pilotos.Any())
            {
                Notificar("A equipe possui pilotos cadastrados!");
                return;
            }

            await _equipeRepository.Remover(id);
        }

        public void Dispose()
        {
            _equipeRepository?.Dispose();
        }
    }
}
