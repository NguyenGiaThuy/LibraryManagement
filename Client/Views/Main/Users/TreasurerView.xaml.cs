using Client.Views.Main.Features;
using Client.Views.Main.Features.Dashboard;
using System;
using System.Windows;

namespace Client.Views.Main.Users
{
    /// <summary>
    /// Interaction logic for TreasurerView.xaml
    /// </summary>
    public partial class TreasurerView : Window
    {
        TreasurerDashboardView treasurerDashboardView = new TreasurerDashboardView();

        CallCardView callCardView = null;
        FineCardView fineCardView = null;

        public TreasurerView()
        {
            this.DataContext = this;
            InitializeComponent();

            TreasurerFrame.Content = treasurerDashboardView.Content;
        }

        //TREASURER ====================================================================================
        private void TreasurerDashboardRBtn_Checked(object sender, RoutedEventArgs e) {
            TreasurerFrame.Content = treasurerDashboardView.Content;
        }

        private async void TreasurerCallCardRBtn_Checked(object sender, RoutedEventArgs e) {
            //if (callCardView != null) {
            //    TreasurerFrame.Content = callCardView.Content;
            //    return;
            //}

            try {
                callCardView = await CallCardView.Create();
                TreasurerFrame.Content = callCardView.Content;
                callCardView.CallCardNewBtn.IsEnabled = false;
                callCardView.CallCardDataGrid.Columns[7].IsHidden = true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async void TreasurerFineCardRBtn_Checked(object sender, RoutedEventArgs e) {
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

        //Close properly the app when the exit button is pressed
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
