using System;
using System.Windows;

namespace Client.Views.Main.Users
{
    /// <summary>
    /// Interaction logic for LibrarianView.xaml
    /// </summary>
    public partial class LibrarianView : Window
    {
        public LibrarianView()
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
