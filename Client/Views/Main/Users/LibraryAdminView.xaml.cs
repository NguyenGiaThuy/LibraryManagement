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

        BookView bookView = new BookView();
        MemberView memberView = new MemberView();
        CallCardView callCardView = new CallCardView();
        BookAuditCardView bookAuditCardView = new BookAuditCardView();
        FineCardView fineCardView = new FineCardView();

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
            UserView userView = null;
            try {
                userView = await UserView.Create();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                LibraryAdminFrame.Content = userView.Content;
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
