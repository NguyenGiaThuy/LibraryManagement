using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
        protected override void OnStartup(StartupEventArgs e)
        {
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
