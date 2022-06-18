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

        UserView userView = null;
        BookView bookView = null;
        MemberView memberView = null;
        CallCardView callCardView = null;
        BookAuditCardView bookAuditCardView = null;
        FineCardView fineCardView = null;

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
            //if (userView != null) {
            //    LibraryAdminFrame.Content = userView.Content;
            //    return;
            //}

            try
            {
                userView = await UserView.Create();
                LibraryAdminFrame.Content = userView.Content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //LIBRARIAN ====================================================================================
        private void LibrarianDashboardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            LibrarianFrame.Content = librarianDashboardView.Content;
        }

        private async void LibrarianMemberRBtn_Checked(object sender, RoutedEventArgs e)
        {
            //if (memberView != null) {
            //    LibrarianFrame.Content = memberView.Content;
            //    return;
            //}

            try {
                memberView = await MemberView.Create();
                LibrarianFrame.Content = memberView.Content;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async void LibrarianBookRBtn_Checked(object sender, RoutedEventArgs e)
        {
            //if (bookView != null) {
            //    LibrarianFrame.Content = bookView.Content;
            //    return;
            //}

            try {
                bookView = await BookView.Create();
                LibrarianFrame.Content = bookView.Content;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async void LibrarianCallCardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            //if (callCardView != null) {
            //    LibrarianFrame.Content = callCardView.Content;
            //    return;
            //}

            try {
                callCardView = await CallCardView.Create();
                LibrarianFrame.Content = callCardView.Content;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //TREASURER ====================================================================================
        private void TreasurerDashboardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            TreasurerFrame.Content = treasurerDashboardView.Content;
        }

        private async void TreasurerCallCardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            //if (callCardView != null) {
            //    TreasurerFrame.Content = callCardView.Content;
            //    return;
            //}

            try {
                callCardView = await CallCardView.Create();
                TreasurerFrame.Content = callCardView.Content;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async void TreasurerFineCardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            //if (fineCardView != null) {
            //    TreasurerFrame.Content = fineCardView.Content;
            //    return;
            //}

            try {
                fineCardView = await FineCardView.Create();
                TreasurerFrame.Content = fineCardView.Content;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //STOREKEEPER ==================================================================================
        private void StorekeeperDashboardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            StorekeeperFrame.Content = storekeeperDashboardView.Content;
        }

        private async void StorekeeperBookRBtn_Checked(object sender, RoutedEventArgs e)
        {
            //if (bookView != null) {
            //    StorekeeperFrame.Content = bookView.Content;
            //    return;
            //}

            try {
                bookView = await BookView.Create();
                StorekeeperFrame.Content = bookView.Content;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async void StorekeeperBACardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            //if (bookAuditCardView != null) {
            //    StorekeeperFrame.Content = bookAuditCardView.Content;
            //    return;
            //}

            try {
                bookAuditCardView = await BookAuditCardView.Create();
                StorekeeperFrame.Content = bookAuditCardView.Content;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //Close properly the application when the exit button is pressed
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
