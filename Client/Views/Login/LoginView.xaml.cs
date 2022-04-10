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

namespace Client.Views.Login {
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window {
        public LoginView() {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e) {
            switch (AccountTextBox.Text) {
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
                case "dev":
                    DevView devView = new DevView();
                    devView.Show();
                    Close();
                    break;
                case "":
                    LoginCheckTxt.Text = "The username & password field cannot be blank!";
                    break;
                default:
                    LoginCheckTxt.Text = "Incorrect username or password!";
                    break;
            }
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e) {
            MessageBox.Show("Please contact to your administrator to retrieve password!", "Forgot password", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //Press Enter key to Login
        private void LoginGrid_PreviewKeyDown(object sender, KeyEventArgs e) {
            UIElement uIElement = e.OriginalSource as UIElement;
            try {
                if ((uIElement != null) && (e.Key == Key.Enter)) {
                    e.Handled = true;
                    LoginBtn_Click(LoginBtn, e);
                }
            }
            catch (Exception ex) { }
        }
    }
}
