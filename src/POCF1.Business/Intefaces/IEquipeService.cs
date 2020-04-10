using POCF1.Business.Models;
using System;
using System.Threading.Tasks;

namespace POCF1.Business.Intefaces
{
    public interface IEquipeService : IDisposable
    {
        Task Adicionar(Equipe equipe);
        Task Atualizar(Equipe equipe);
        Task Remover(int id);
    }
}
