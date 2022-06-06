using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using Client;
using Client.Views;
using Client.Views.Login;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string BaseAddress = "https://localhost:5001/";
        public static HttpClient Client = new HttpClient();

        protected override void OnStartup(StartupEventArgs e)
        {
            // Update port # in the following line.
            Client.BaseAddress = new Uri(BaseAddress);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

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
