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
using System.Diagnostics;
using System.Windows.Navigation;
using Client.Views.Login;
using Client.Views.Main;
using Client.Views.Main.Users;
using Client.Views.Main.Features;

namespace Client.Views.Login
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (AccountTextBox.Text)
            {
                case "librarian":
                    LibrarianView librarianView = new LibrarianView();
                    librarianView.Show();
                    Close();
                    break;
                case "libraryadmin":
                    LibraryAdminView libraryAdminView = new LibraryAdminView();
                    libraryAdminView.Show();
                    Close();
                    break;
                case "storekeeper":
                    StorekeeperView storekeeperView = new StorekeeperView();
                    storekeeperView.Show();
                    Close();
                    break;
                case "treasurer":
                    TreasurerView treasurerView = new TreasurerView();
                    treasurerView.Show();
                    Close();
                    break;
                case "memberview":
                    MemberView memberView = new MemberView();
                    memberView.Show();
                    Close();
                    break;
                case "callcardsview":
                    CallCardView callCardView = new CallCardView();
                    callCardView.Show();
                    Close();
                    break;
                default:
                    DevView devView = new DevView();
                    devView.Show();
                    break;
            }
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            ForgotPasswordView forgotPasswordView = new ForgotPasswordView();
            forgotPasswordView.Show();
        }
    }
}
