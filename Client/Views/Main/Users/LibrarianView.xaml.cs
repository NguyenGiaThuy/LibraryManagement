using Client.Views.Main.Features;
using Client.Views.Main.Features.Dashboard;
using System;
using System.Windows;

namespace Client.Views.Main.Users
{
    /// <summary>
    /// Interaction logic for LibrarianView.xaml
    /// </summary>
    public partial class LibrarianView : Window
    {
        LibrarianDashboardView librarianDashboardView = new LibrarianDashboardView();

        BookView bookView = null;
        MemberView memberView = null;
        CallCardView callCardView = null;

        public LibrarianView()
        {
            this.DataContext = this;
            InitializeComponent();

            LibrarianFrame.Content = librarianDashboardView.Content;
        }

        //LIBRARIAN ====================================================================================
        private void LibrarianDashboardRBtn_Checked(object sender, RoutedEventArgs e) {
            LibrarianFrame.Content = librarianDashboardView.Content;
        }

        private async void LibrarianMemberRBtn_Checked(object sender, RoutedEventArgs e) {
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

        private async void LibrarianBookRBtn_Checked(object sender, RoutedEventArgs e) {
            //if (bookView != null) {
            //    LibrarianFrame.Content = bookView.Content;
            //    return;
            //}

            try {
                bookView = await BookView.Create();
                LibrarianFrame.Content = bookView.Content;
                bookView.BookNewBtn.IsEnabled = false;
                bookView.BookDataGrid.Columns[5].IsHidden = true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async void LibrarianCallCardRBtn_Checked(object sender, RoutedEventArgs e) {
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

        //Close properly the app when the exit button is pressed
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
