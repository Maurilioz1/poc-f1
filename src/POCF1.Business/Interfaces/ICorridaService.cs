using POCF1.Business.Models;
using System;
using System.Threading.Tasks;

namespace POCF1.Business.Interfaces
{
    public interface ICorridaService : IDisposable
    {
        Task<bool> Adicionar(Corrida corrida);
        Task<bool> Atualizar(Corrida corrida);
        Task<bool> Remover(int id);
    }
}
