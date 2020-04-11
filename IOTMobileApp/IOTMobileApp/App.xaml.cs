using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IOTMobileApp.Services;
using IOTMobileApp.Views;
using System.Threading.Tasks;

namespace IOTMobileApp
{
    public partial class App : Application
    {
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
        public static bool UseMockDataStore = true;
        public static string DatabaseLocalion;

        public App( string databaseLocation)
        {
            InitializeComponent();

            DependencyService.Register<DataStore>();
            MainPage = new NavigationPage(new LoginPage());
            DatabaseLocalion = databaseLocation;

            Task.Run(MqttService.Init);
        }
        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
