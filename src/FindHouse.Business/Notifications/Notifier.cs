using System.Collections.Generic;
using System.Linq;
using FindHouse.Business.Interfaces;

namespace FindHouse.Business.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> ObterNotificacoes()
        {
            return _notifications;
        }

        public bool TemNotificacao()
        {
            return _notifications.Any();
        }
    }
}
