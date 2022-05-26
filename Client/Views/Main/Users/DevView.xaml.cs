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

namespace Client.Views.Main {
    /// <summary>
    /// Interaction logic for DevView.xaml
    /// </summary>
    public partial class DevView : Window {
        private List<Window> views;
        private Window view;

        LibrarianDashboardView librarianDashboardView = new LibrarianDashboardView();
        LibraryAdminDashboardView libraryAdminDashboardView = new LibraryAdminDashboardView();
        StorekeeperDashboardView storekeeperDashboardView = new StorekeeperDashboardView();
        TreasurerDashboardView treasurerDashboardView = new TreasurerDashboardView();

        public DevView() {
            InitializeComponent();

            views = new List<Window>();

            LibraryAdminFrame.Content = libraryAdminDashboardView.Content;
            LibrarianFrame.Content = librarianDashboardView.Content;
            TreasurerFrame.Content = treasurerDashboardView.Content;
            StorekeeperFrame.Content = storekeeperDashboardView.Content;
        }

        //LIBRARY ADMINISTRATOR ========================================================================
        private void LibraryAdminDashboardRBtn_Checked(object sender, RoutedEventArgs e) {
            LibraryAdminFrame.Content = libraryAdminDashboardView.Content;
        }

        private void LibraryAdminUserRBtn_Checked(object sender, RoutedEventArgs e) {
            //LibraryAdminFrame.Content = userView.Content;
        }

        //LIBRARIAN ====================================================================================
        private void LibrarianDashboardRBtn_Checked(object sender, RoutedEventArgs e) {
            LibrarianFrame.Content = librarianDashboardView.Content;
        }

        private void LibrarianMemberRBtn_Checked(object sender, RoutedEventArgs e) {
            // MemberView exists
            foreach (var v in views)
                if (v is MemberView) {
                    view = v;
                    break;
                }

            // MemberView does not exist
            if (view is not MemberView) {
                view = new MemberView();
                views.Add(view);
            }

            LibrarianFrame.Content = view.Content;

            if (views.Count > 2) views.RemoveAt(0);
        }

        private void LibrarianBookRBtn_Checked(object sender, RoutedEventArgs e) {
            // BookView exists
            foreach (var v in views)
                if (v is BookView) {
                    view = v;
                    break;
                }

            // BookView does not exist
            if (view is not BookView) {
                view = new BookView();
                views.Add(view);
            }

            LibrarianFrame.Content = view.Content;

            if (views.Count > 2) views.RemoveAt(0);
        }

        private void LibrarianCallCardRBtn_Checked(object sender, RoutedEventArgs e) {
            // CallCardView exists
            foreach (var v in views)
                if (v is CallCardView) {
                    view = v;
                    break;
                }

            // CallCardView does not exist
            if (view is not CallCardView) {
                view = new CallCardView();
                views.Add(view);
            }

            LibrarianFrame.Content = view.Content;

            if (views.Count > 2) views.RemoveAt(0);
        }

        //TREASURER ====================================================================================
        private void TreasurerDashboardRBtn_Checked(object sender, RoutedEventArgs e) {
            TreasurerFrame.Content = treasurerDashboardView.Content;
        }

        private void TreasurerCallCardRBtn_Checked(object sender, RoutedEventArgs e) {
            //TreasurerFrame.Content = callCardView.Content;
        }

        //STOREKEEPER ==================================================================================
        private void StorekeeperDashboardRBtn_Checked(object sender, RoutedEventArgs e) {
            StorekeeperFrame.Content = storekeeperDashboardView.Content;
        }

        private void StorekeeperBookRBtn_Checked(object sender, RoutedEventArgs e) {
            //StorekeeperFrame.Content = bookView.Content;
        }

        private void StorekeeperBMRBtn_Checked(object sender, RoutedEventArgs e) {
            //StorekeeperFrame.Content = bMCardView.Content;
        }

        //Close properly the application when the exit button is pressed
        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
