using POCF1.Business.Notificacoes;
using System.Collections.Generic;

namespace POCF1.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
