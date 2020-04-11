using POCF1.Business.Models;
using System;
using System.Threading.Tasks;

namespace POCF1.Business.Interfaces
{
    public interface IPilotoService : IDisposable
    {
        Task<bool> Adicionar(Piloto piloto);
        Task<bool> Atualizar(Piloto piloto);
        Task<bool> Remover(int id);
    }
}
