using POCF1.Business.Interfaces;
using POCF1.Business.Models;
using POCF1.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace POCF1.Business.Services
{
    public class CorridaService : BaseService, ICorridaService
    {
        private readonly ICorridaRepository _corridaRepository;
        private readonly IPilotoRepository _pilotoRepository;

        public CorridaService(ICorridaRepository corridaRepository, IPilotoRepository pilotoRepository, INotificador notificador) : base(notificador)
        {
            _corridaRepository = corridaRepository;
            _pilotoRepository = pilotoRepository;
        }

        public async Task<bool> Adicionar(Corrida corrida)
        {
            if (!ExecutarValidacao(new CorridaValidation(), corrida)) return false;

            var trajeto = new Random().Next(250, 350);

            var pilotos = await _pilotoRepository.ObterTodos();

            var podioTempo = pilotos.Select(piloto => new Tuple<int, double>(piloto.Id, CalcularTempo(piloto, trajeto)))
                                    .Where(t => t.Item2 < double.MaxValue)
                                    .OrderBy(t => t.Item2)
                                    .Take(3)
                                    .ToList();

            corrida.TrajetoTotalCircuito = trajeto;
            corrida.DataCorrida = DateTime.Now;

            corrida.Piloto1Id = podioTempo.ElementAtOrDefault(0)?.Item1;
            if (podioTempo.ElementAtOrDefault(0) != null)
                corrida.Tempo1 = TimeSpan.FromMinutes(podioTempo.ElementAt(0).Item2);

            corrida.Piloto2Id = podioTempo.ElementAtOrDefault(1)?.Item1;
            if (podioTempo.ElementAtOrDefault(1) != null)
                corrida.Tempo2 = TimeSpan.FromMinutes(podioTempo.ElementAt(1).Item2);

            corrida.Piloto3Id = podioTempo.ElementAtOrDefault(2)?.Item1;
            if(podioTempo.ElementAtOrDefault(2) != null)
                corrida.Tempo3 = TimeSpan.FromMinutes(podioTempo.ElementAt(2).Item2);

            await _corridaRepository.Adicionar(corrida);
            return true;
        }

        private double CalcularTempo(Piloto piloto, int trajetoTotalCircuito)
        {
            var potenciaCarro = piloto.Equipe.PotenciaCarro;
            var aerodinamicaCarro = piloto.Equipe.AerodinamicaCarro;
            var nivelExperienciaPiloto = piloto.NivelExperiencia;
            var posicaoLargada = piloto.PosicaoLargada;
            var quantidadeParadas = piloto.QuantidadeParadas;

            var consumo = 260 / ((potenciaCarro * 1.0 ) - 300);

            var distancia = consumo * (150 * (quantidadeParadas + 1));

            if (distancia >= trajetoTotalCircuito)
            {
                return (trajetoTotalCircuito / (Math.Sqrt(potenciaCarro / 100) + (Math.Pow(aerodinamicaCarro, (1 / 10))) +
                    (Math.Pow(nivelExperienciaPiloto, (1 / 10))))) +
                    (Math.Pow(posicaoLargada - 1, 2) / 100) + quantidadeParadas;
            }

            return double.MaxValue;
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
