﻿using Client.Models;
using Client.Views.Main;
using Client.Views.Main.Users;
using Client.Views.Main.Features.Dialogs;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client.Views.Login
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private Credential credential = new Credential();

        private bool enterPressed;

        public LoginView()
        {
            InitializeComponent();
            enterPressed = false;
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

        private async Task<LibUser> LogInAsync(string path, string username, string password)
        {
            LibUser user = new LibUser(username, password, null, null, null, null, null, null, null, null);
            var response = await App.Client.PostAsJsonAsync(path, user);
            response.EnsureSuccessStatusCode();
            user = await response.Content.ReadAsAsync<LibUser>();
            return user;
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginBtn.IsEnabled = false;

            credential.Username = AccountTextBox.Text.Trim();
            credential.Password = PasswordBox.Password.Trim();

            UsernameCheckTxt.Text = "";
            PasswordCheckTxt.Text = "";
            if (credential.Username == "" || credential.Password == "")
            {
                if (credential.Username == "") UsernameCheckTxt.Text = "Username field cannot be blank!";
                if (credential.Password == "") PasswordCheckTxt.Text = "Password field cannot be blank!";
                return;
            }

            try
            {
                App.User = await LogInAsync($"api/libusers/login", credential.Username, credential.Password);

                if (App.User.Status == LibUser.UserStatus.Inactive)
                {
                    MessageBox.Show("Your account is inactive. Please contact manager for more details.");
                    return;
                }

                switch (App.User.Department)
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
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                    MessageBox.Show("Incorrect username or password.", "Login failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                else MessageBox.Show(ex.Message);

                LoginBtn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LoginBtn.IsEnabled = true;
            }
        }

        //Press Enter key to Login
        private async void LoginGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            UIElement uIElement = e.OriginalSource as UIElement;

            if ((uIElement != null) && (e.Key == Key.Enter) && !enterPressed)
            {
                LoginBtn.IsEnabled = false;
                enterPressed = true;
                e.Handled = true;

                credential.Username = AccountTextBox.Text.Trim();
                credential.Password = PasswordBox.Password.Trim();

                UsernameCheckTxt.Text = "";
                PasswordCheckTxt.Text = "";
                if (credential.Username == "" || credential.Password == "")
                {
                    if (credential.Username == "") UsernameCheckTxt.Text = "Username field cannot be blank!";
                    if (credential.Password == "") PasswordCheckTxt.Text = "Password field cannot be blank!";
                    return;
                }

                try
                {
                    App.User = await LogInAsync($"api/libusers/login", credential.Username, credential.Password);

                    if (App.User.Status == LibUser.UserStatus.Inactive)
                    {
                        MessageBox.Show("Your account is inactive. Please contact manager for more details.");
                        return;
                    }

                    switch (App.User.Department)
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
                catch (HttpRequestException ex)
                {
                    if (ex.StatusCode == HttpStatusCode.NotFound)
                        MessageBox.Show("Incorrect username or password.", "Login failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                    else MessageBox.Show(ex.Message);

                    LoginBtn.IsEnabled = true;
                    enterPressed = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    LoginBtn.IsEnabled = true;
                    enterPressed = false;
                }
            }
        }
    }
}