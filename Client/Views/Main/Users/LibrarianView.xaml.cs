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

        BookView bookView = new BookView();
        MemberView memberView = new MemberView();
        CallCardView callCardView = new CallCardView();

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

        private void LibrarianMemberRBtn_Checked(object sender, RoutedEventArgs e) {
            LibrarianFrame.Content = memberView.Content;
        }

        private void LibrarianBookRBtn_Checked(object sender, RoutedEventArgs e) {
            LibrarianFrame.Content = bookView.Content;
        }

        private void LibrarianCallCardRBtn_Checked(object sender, RoutedEventArgs e) {
            LibrarianFrame.Content = callCardView.Content;
        }

        //Close properly the app when the exit button is pressed
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
