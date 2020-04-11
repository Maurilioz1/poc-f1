using POCF1.Business.Interfaces;
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

        public async Task<bool> Adicionar(Equipe equipe)
        {
            if (!ExecutarValidacao(new EquipeValidation(), equipe)) return false;

            await _equipeRepository.Adicionar(equipe);
            return true;
        }

        public async Task<bool> Atualizar(Equipe equipe)
        {
            if (!ExecutarValidacao(new EquipeValidation(), equipe)) return false;

            await _equipeRepository.Atualizar(equipe);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            if (_equipeRepository.ObterEquipePilotos(id).Result.Pilotos.Any())
            {
                Notificar("A equipe possui pilotos cadastrados!");
                return false;
            }

            await _equipeRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _equipeRepository?.Dispose();
        }
    }
}
