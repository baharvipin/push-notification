using Plugin.Firebase.CloudMessaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwsSnsFcm.Services
{
    public class FirebaseNotificationService
    {
        public async Task InitializeAsync()
        {
            // Ensure Firebase Cloud Messaging is valid
              CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
             

            // Handle received notifications
            CrossFirebaseCloudMessaging.Current.NotificationReceived += (s, e) =>
            {
                Console.WriteLine($"✅ Firebase message before");
                string message = $"📩 {e.Notification.Title}: {e.Notification.Body}";
                Console.WriteLine($"✅ Firebase message: {message}");
                NotificationService.Instance.AddNotification(message);
            };

            // Retrieve Firebase Token
            var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
            Console.WriteLine($"✅ Firebase Token: {token}");
        }
    }
}
