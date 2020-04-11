using POCF1.Business.Models;
using System;
using System.Threading.Tasks;

namespace POCF1.Business.Interfaces
{
    public interface IEquipeService : IDisposable
    {
        Task<bool> Adicionar(Equipe equipe);
        Task<bool> Atualizar(Equipe equipe);
        Task<bool> Remover(int id);
    }
}
