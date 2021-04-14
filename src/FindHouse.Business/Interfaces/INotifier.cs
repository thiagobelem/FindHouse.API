using FindHouse.Business.Notifications;
using System.Collections.Generic;

namespace FindHouse.Business.Interfaces
{
    public interface INotifier
    {
        bool TemNotificacao();

        List<Notification> ObterNotificacoes();

        void Handle(Notification notification);
    }
}
