using Plugin.Firebase.CloudMessaging;
using System.Collections.ObjectModel;

namespace AwsSnsFcm
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public ObservableCollection<string> Notifications => Services.NotificationService.Instance.Notifications;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            Services.NotificationService.Instance.OnNotificationReceived += (message) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("New Notification", message, "OK");
                });
            };
        }


        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
            var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
            Console.WriteLine($"FCM token: {token}");
        }

         
    }

}
