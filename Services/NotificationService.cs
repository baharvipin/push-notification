using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwsSnsFcm.Services
{
    public class NotificationService
    {
        private static readonly Lazy<NotificationService> instance = new(() => new NotificationService());
        public static NotificationService Instance => instance.Value;

        public ObservableCollection<string> Notifications { get; private set; } = new();

        public event Action<string> OnNotificationReceived;

        public void AddNotification(string message)
        {
            Notifications.Add(message);
            OnNotificationReceived?.Invoke(message);
        }
    }
}
