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

        BookView bookView = null;
        BookAuditCardView bookAuditCardView = null;

        public StorekeeperView() {
            this.DataContext = this;
            InitializeComponent();

            StorekeeperFrame.Content = storekeeperDashboardView.Content;
        }

        //STOREKEEPER ==================================================================================
        private void StorekeeperDashboardRBtn_Checked(object sender, RoutedEventArgs e) {
            StorekeeperFrame.Content = storekeeperDashboardView.Content;
        }

        private async void StorekeeperBookRBtn_Checked(object sender, RoutedEventArgs e) {
            if (bookView != null) {
                StorekeeperFrame.Content = bookView.Content;
                return;
            }

            try {
                bookView = await BookView.Create();
                StorekeeperFrame.Content = bookView.Content;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async void StorekeeperBACardRBtn_Checked(object sender, RoutedEventArgs e) {
            if (bookAuditCardView != null) {
                StorekeeperFrame.Content = bookAuditCardView.Content;
                return;
            }

            try {
                bookAuditCardView = await BookAuditCardView.Create();
                StorekeeperFrame.Content = bookAuditCardView.Content;
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
