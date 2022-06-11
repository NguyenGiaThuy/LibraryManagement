using Client.Views.Main.Features;
using Client.Views.Main.Features.Dashboard;
using System;
using System.Windows;

namespace Client.Views.Main
{
    /// <summary>
    /// Interaction logic for DevView.xaml
    /// </summary>
    public partial class DevView : Window
    {
        LibrarianDashboardView librarianDashboardView = new LibrarianDashboardView();
        LibraryAdminDashboardView libraryAdminDashboardView = new LibraryAdminDashboardView();
        StorekeeperDashboardView storekeeperDashboardView = new StorekeeperDashboardView();
        TreasurerDashboardView treasurerDashboardView = new TreasurerDashboardView();

        BookView bookView = new BookView();
        MemberView memberView = new MemberView();
        CallCardView callCardView = new CallCardView();
        BookAuditCardView bookAuditCardView = new BookAuditCardView();
        FineCardView fineCardView = new FineCardView();

        public DevView()
        {
            this.DataContext = this;
            InitializeComponent();

            LibraryAdminFrame.Content = libraryAdminDashboardView.Content;
            LibrarianFrame.Content = librarianDashboardView.Content;
            TreasurerFrame.Content = treasurerDashboardView.Content;
            StorekeeperFrame.Content = storekeeperDashboardView.Content;
        }

        //LIBRARY ADMINISTRATOR ========================================================================
        private void LibraryAdminDashboardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            LibraryAdminFrame.Content = libraryAdminDashboardView.Content;
        }

        private async void LibraryAdminUserRBtn_Checked(object sender, RoutedEventArgs e)
        {
            UserView userView = null;
            try
            {
                userView = await UserView.Create();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LibraryAdminFrame.Content = userView.Content;
            }
        }

        //LIBRARIAN ====================================================================================
        private void LibrarianDashboardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            LibrarianFrame.Content = librarianDashboardView.Content;
        }

        private void LibrarianMemberRBtn_Checked(object sender, RoutedEventArgs e)
        {
            LibrarianFrame.Content = memberView.Content;
        }

        private void LibrarianBookRBtn_Checked(object sender, RoutedEventArgs e)
        {
            LibrarianFrame.Content = bookView.Content;
        }

        private void LibrarianCallCardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            LibrarianFrame.Content = callCardView.Content;
        }

        //TREASURER ====================================================================================
        private void TreasurerDashboardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            TreasurerFrame.Content = treasurerDashboardView.Content;
        }

        private void TreasurerCallCardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            TreasurerFrame.Content = callCardView.Content;
        }

        private void TreasurerFineCardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            TreasurerFrame.Content = fineCardView.Content;
        }

        //STOREKEEPER ==================================================================================
        private void StorekeeperDashboardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            StorekeeperFrame.Content = storekeeperDashboardView.Content;
        }

        private void StorekeeperBookRBtn_Checked(object sender, RoutedEventArgs e)
        {
            StorekeeperFrame.Content = bookView.Content;
        }

        private void StorekeeperBACardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            StorekeeperFrame.Content = bookAuditCardView.Content;
        }

        //Close properly the application when the exit button is pressed
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
