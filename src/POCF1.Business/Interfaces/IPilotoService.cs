using POCF1.Business.Models;
using System;
using System.Threading.Tasks;

namespace POCF1.Business.Interfaces
{
    public interface IPilotoService : IDisposable
    {
        Task Adicionar(Piloto piloto);
        Task Atualizar(Piloto piloto);
        Task Remover(int id);
    }
}
