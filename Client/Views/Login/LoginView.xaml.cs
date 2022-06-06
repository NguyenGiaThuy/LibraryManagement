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
using System.Net.Http;
using System.Net.Http.Headers;
using Client.Models;

namespace Client.Views.Login {
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window {
        private Credential credential = new Credential();

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

        private async Task<LibUser> GetUser(LibUser user, string path)
        {
            HttpResponseMessage response = await App.Client.PostAsJsonAsync(path, user);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<LibUser>();
            }

            return user;
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e) {
            credential.Username = AccountTextBox.Text.Trim();
            credential.Password = PasswordBox.Password.Trim();

            if (credential.Username == "") 
            { 
                LoginCheckTxt.Text = "Username field cannot be blank!";
                return;
            }
            if (credential.Password == "")
            {
                LoginCheckTxt.Text = "Password field cannot be blank!";
                return;
            }

            LibUser user = new LibUser(credential.Username, credential.Password, null, null, null, null, null, null, null, null);
            try
            {
                user = await GetUser(user, $"api/libusers/login");

                if (credential.Password != user.Password)
                {
                    LoginCheckTxt.Text = "Incorrect username or password";
                    return;
                }

                credential.StatusCode = (LibUser.UserStatus)user.Status;

                if (credential.StatusCode == LibUser.UserStatus.Inactive)
                {
                    MessageBox.Show("Your account is inactive. Please contact manager for more details.");
                    return;
                }

                credential.DepartmentCode = (LibUser.UserDepartment)user.Department;

                switch (credential.DepartmentCode)
                {
                    case LibUser.UserDepartment.Librarian:
                        LibrarianView librarianView = new LibrarianView();
                        librarianView.Show();
                        Close();
                        break;
                    case LibUser.UserDepartment.Administrator:
                        LibraryAdminView libraryAdminView = new LibraryAdminView();
                        libraryAdminView.Show();
                        Close();
                        break;
                    case LibUser.UserDepartment.Storekeeper:
                        StorekeeperView storekeeperView = new StorekeeperView();
                        storekeeperView.Show();
                        Close();
                        break;
                    case LibUser.UserDepartment.Treasurer:
                        TreasurerView treasurerView = new TreasurerView();
                        treasurerView.Show();
                        Close();
                        break;
                    case LibUser.UserDepartment.Developer:
                        DevView devView = new DevView();
                        devView.Show();
                        Close();
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e) {
            MessageBox.Show("Please contact to your administrator to retrieve password!", "Forgot password", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //Press Enter key to Login
        private async void LoginGrid_PreviewKeyDown(object sender, KeyEventArgs e) {
            UIElement uIElement = e.OriginalSource as UIElement;

            if ((uIElement != null) && (e.Key == Key.Enter))
            {
                e.Handled = true;

                credential.Username = AccountTextBox.Text.Trim();
                credential.Password = PasswordBox.Password.Trim();

                if (credential.Username == "")
                {
                    LoginCheckTxt.Text = "Username field cannot be blank!";
                    return;
                }
                if (credential.Password == "")
                {
                    LoginCheckTxt.Text = "Password field cannot be blank!";
                    return;
                }

                LibUser user = new LibUser(credential.Username, credential.Password, null, null, null, null, null, null, null, null);
                try
                {
                    user = await GetUser(user, $"api/libusers/login");

                    if (credential.Password != user.Password)
                    {
                        LoginCheckTxt.Text = "Incorrect username or password";
                        return;
                    }

                    credential.StatusCode = (LibUser.UserStatus)user.Status;

                    if (credential.StatusCode == LibUser.UserStatus.Inactive)
                    {
                        MessageBox.Show("Your account is inactive. Please contact manager for more details.");
                        return;
                    }

                    credential.DepartmentCode = (LibUser.UserDepartment)user.Department;

                    switch (credential.DepartmentCode)
                    {
                        case LibUser.UserDepartment.Librarian:
                            LibrarianView librarianView = new LibrarianView();
                            librarianView.Show();
                            Close();
                            break;
                        case LibUser.UserDepartment.Administrator:
                            LibraryAdminView libraryAdminView = new LibraryAdminView();
                            libraryAdminView.Show();
                            Close();
                            break;
                        case LibUser.UserDepartment.Storekeeper:
                            StorekeeperView storekeeperView = new StorekeeperView();
                            storekeeperView.Show();
                            Close();
                            break;
                        case LibUser.UserDepartment.Treasurer:
                            TreasurerView treasurerView = new TreasurerView();
                            treasurerView.Show();
                            Close();
                            break;
                        case LibUser.UserDepartment.Developer:
                            DevView devView = new DevView();
                            devView.Show();
                            Close();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
