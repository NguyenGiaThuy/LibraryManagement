using System;
using System.Windows;

namespace Client.Views.Main.Users
{
    /// <summary>
    /// Interaction logic for TreasurerView.xaml
    /// </summary>
    public partial class TreasurerView : Window
    {
        public TreasurerView()
        {
            InitializeComponent();
        }

        //Close properly the app when the exit button is pressed
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
