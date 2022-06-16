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

        CallCardView callCardView = new CallCardView();
        FineCardView fineCardView = new FineCardView();

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

        private void TreasurerCallCardRBtn_Checked(object sender, RoutedEventArgs e) {
            TreasurerFrame.Content = callCardView.Content;
        }

        private void TreasurerFineCardRBtn_Checked(object sender, RoutedEventArgs e) {
            TreasurerFrame.Content = fineCardView.Content;
        }

        //Close properly the app when the exit button is pressed
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
