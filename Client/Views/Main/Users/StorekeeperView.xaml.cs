using Client.Views.Main.Features;
using Client.Views.Main.Features.Dashboard;
using System;
using System.Windows;

namespace Client.Views.Main.Users
{
    /// <summary>
    /// Interaction logic for StorekeeperView.xaml
    /// </summary>
    public partial class StorekeeperView : Window
    {
        StorekeeperDashboardView storekeeperDashboardView = new StorekeeperDashboardView();

        BookView bookView = new BookView();
        BookAuditCardView bookAuditCardView = new BookAuditCardView();

        public StorekeeperView() {
            this.DataContext = this;
            InitializeComponent();

            StorekeeperFrame.Content = storekeeperDashboardView.Content;
        }

        //STOREKEEPER ==================================================================================
        private void StorekeeperDashboardRBtn_Checked(object sender, RoutedEventArgs e) {
            StorekeeperFrame.Content = storekeeperDashboardView.Content;
        }

        private void StorekeeperBookRBtn_Checked(object sender, RoutedEventArgs e) {
            StorekeeperFrame.Content = bookView.Content;
        }

        private void StorekeeperBACardRBtn_Checked(object sender, RoutedEventArgs e) {
            StorekeeperFrame.Content = bookAuditCardView.Content;
        }

        //Close properly the app when the exit button is pressed
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
