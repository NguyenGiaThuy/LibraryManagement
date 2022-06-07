using Client.Models;
using Client.Views.Login;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string BaseAddress = "https://localhost:7277/";
        public static HttpClient Client = new HttpClient();
        public static LibUser User;

        protected override void OnStartup(StartupEventArgs e)
        {
            // Update port # in the following line.
            Client.BaseAddress = new Uri(BaseAddress);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            User = null;

            LoginView loginView = new LoginView();
            loginView.Show();

            base.OnStartup(e);
        }

        public App()
        {
            ShutdownMode = ShutdownMode.OnLastWindowClose;
        }
    }
}
