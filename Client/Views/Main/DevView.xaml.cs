using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Client;
using Client.Views;
using Client.Views.Login;
using Client.Views.Main;
using Client.Views.Main.Features;
using Client.Views.Main.Features.Dashboard;
using Client.Views.Main.Users;

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
        BMCardViewCardView bMCardView = new BMCardViewCardView();
        UserView userView = new UserView();

        public DevView()
        {
            InitializeComponent();

            LibraryAdminFrame.Content = libraryAdminDashboardView.Content;
            LibrarianFrame.Content = librarianDashboardView.Content;
            TreasurerFrame.Content = treasurerDashboardView.Content;
            StorekeeperFrame.Content = storekeeperDashboardView.Content;
        }

        //LIBRARY ADMINISTRATOR ========================================================================
        private void LibraryAdminDashboardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            try  //Ignored when initializing [User View] because [Dashboard Radio Button] will be the first checked radio button in the side bar, the [Frame] then have not initialized yet.
            {
                LibraryAdminFrame.Content = libraryAdminDashboardView.Content;
            }
            catch (Exception ex)
            {
                //Ignored
            }
        }

        private void LibraryAdminUserRBtn_Checked(object sender, RoutedEventArgs e)
        {
            LibraryAdminFrame.Content = userView.Content;
        }

        //LIBRARIAN ====================================================================================
        private void LibrarianDashboardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            try //Ignored when initializing [User View] because [Dashboard Radio Button] will be the first checked radio button in the side bar, the [Frame] then have not initialized yet.
            {
                LibrarianFrame.Content = librarianDashboardView.Content;
            }
            catch (Exception ex)
            {
                //Ignored
            }
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
            try //Ignored when initializing [User View] because [Dashboard Radio Button] will be the first checked radio button in the side bar, the [Frame] then have not initialized yet.
            {
                TreasurerFrame.Content = treasurerDashboardView.Content;
            }
            catch (Exception ex)
            {
                //Ignored
            }
        }

        private void TreasurerCallCardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            TreasurerFrame.Content = callCardView.Content;
        }

        //STOREKEEPER ==================================================================================
        private void StorekeeperDashboardRBtn_Checked(object sender, RoutedEventArgs e)
        {
            try //Ignored when initializing [User View] because [Dashboard Radio Button] will be the first checked radio button in the side bar, the [Frame] then have not initialized yet.
            {
                StorekeeperFrame.Content = storekeeperDashboardView.Content;
            }
            catch (Exception ex)
            {
                //Ignored
            }
        }

        private void StorekeeperBookRBtn_Checked(object sender, RoutedEventArgs e)
        {
            StorekeeperFrame.Content = bookView.Content;
        }

        private void StorekeeperBMRBtn_Checked(object sender, RoutedEventArgs e)
        {
            StorekeeperFrame.Content = bMCardView.Content;
        }

        //Close properly the application when the exit button is pressed
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        private void LogoutBtn1_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            Close();
        }

        private void ExitBtn1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
