using Client.Views.Main.Features;
using Client.Views.Main.Features.Dashboard;
using System;
using System.Windows;

namespace Client.Views.Main.Users
{
    /// <summary>
    /// Interaction logic for LibraryAdminView.xaml
    /// </summary>
    public partial class LibraryAdminView : Window
    {
        LibraryAdminDashboardView libraryAdminDashboardView = new LibraryAdminDashboardView();

        UserView userView = null;

        public LibraryAdminView()
        {
            this.DataContext = this;
            InitializeComponent();

            LibraryAdminFrame.Content = libraryAdminDashboardView.Content;
        }

        //LIBRARY ADMINISTRATOR ========================================================================
        private void LibraryAdminDashboardRBtn_Checked(object sender, RoutedEventArgs e) {
            LibraryAdminFrame.Content = libraryAdminDashboardView.Content;
        }

        private async void LibraryAdminUserRBtn_Checked(object sender, RoutedEventArgs e) {
            if (userView != null) {
                LibraryAdminFrame.Content = userView.Content;
                return;
            }

            try {
                userView = await UserView.Create();
                LibraryAdminFrame.Content = userView.Content;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //Close properly the app when the exit button is pressed
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
