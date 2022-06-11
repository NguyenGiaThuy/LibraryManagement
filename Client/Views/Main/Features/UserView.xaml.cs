using Client.Models;
using Client.Views.Main.Features.Dialogs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Client.Views.Main.Features
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>

    public partial class UserView : Window
    {
        UserCreateForm userCreateForm;
        UserUpdateForm userUpdateForm;
        List<LibUser> userList;
        LibUser selectedUser;

        public static async Task<UserView> Create()
        {
            var userView = new UserView();
            userView.userList = await userView.GetUsersAsync($"api/libusers");
            userView.UserDataGrid.ItemsSource = userView.userList;
            return userView;
        }

        private UserView()
        {
            InitializeComponent();

            UserDataGrid.Focus();
            userUpdateForm = new UserUpdateForm();
            userCreateForm = new UserCreateForm();
            userCreateForm.OnUserFormSaved += UserCreateForm_OnFormSaved;
            userUpdateForm.OnUserFormSaved += UserUpdateForm_OnFormSaved;
        }

        ~UserView()
        {
            userCreateForm.OnUserFormSaved -= UserCreateForm_OnFormSaved;
            userUpdateForm.OnUserFormSaved -= UserUpdateForm_OnFormSaved;
        }

        private async Task<List<LibUser>> GetUsersAsync(string path)
        {
            List<LibUser> users = null;
            var response = await App.Client.GetAsync(path);
            if (response.IsSuccessStatusCode) users = await response.Content.ReadAsAsync<List<LibUser>>();
            return users;
        }

        private async Task<LibUser> DisableUserAsync(string path)
        {
            LibUser user = new LibUser();
            var response = await App.Client.PutAsJsonAsync(path, user);
            response.EnsureSuccessStatusCode();
            user = await response.Content.ReadAsAsync<LibUser>();
            return user;
        }

        private void UserCreateForm_OnFormSaved(LibUser user)
        {
            //selectedUser.CopyFrom(user);
            //UpdateUserSidePanel(selectedUser);
            //UserDataGrid.ItemsSource = null;
            //UserDataGrid.ItemsSource = userList;
        }

        private void UserUpdateForm_OnFormSaved(LibUser user)
        {
            selectedUser.CopyFrom(user);
            UpdateUserSidePanel(selectedUser);
            UserDataGrid.ItemsSource = null;
            UserDataGrid.ItemsSource = userList;
        }

        private void UpdateUserSidePanel(LibUser user)
        {
            DateTime dob = user.Dob != null ? (DateTime)user.Dob : DateTime.MinValue;
            DOBTxt.Text = selectedUser.Dob != null ? dob.ToString("dd-MM-yyyy") : "";

            UserNameTxt.Text = user.Name ?? "";
            AddressTxt.Text = user.Address ?? "";
            MobileTxt.Text = user.Mobile ?? "";
            EducationTxt.Text = user.Education != null ? user.Education.ToString() : "";
            DepartmentTxt.Text = user.Department != null ? user.Department.ToString() : "";
            PositionTxt.Text = user.Position != null ? user.Position.ToString() : "";
            UserImg.Source = user.ImageUrl != null ? new BitmapImage(new Uri(user.ImageUrl)) : null;
        }

        private void UserNewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedUser = UserDataGrid.SelectedItem as LibUser;

            DateTime dob = selectedUser.Dob != null ? (DateTime)selectedUser.Dob : DateTime.MinValue;
            userUpdateForm.DateOfBirthComboBox.Text = selectedUser.Dob != null ? dob.ToString("dd-MM-yyyy") : "";

            userUpdateForm.UserIdTxt.Text = selectedUser.UserId;
            userUpdateForm.PasswordTxt.Password = selectedUser.Password;
            userUpdateForm.NameTxt.Text = selectedUser.Name ?? "";
            userUpdateForm.AddressTxt.Text = selectedUser.Address ?? "";
            userUpdateForm.MobileTxt.Text = selectedUser.Mobile ?? "";
            userUpdateForm.EducationComboBox.SelectedIndex = selectedUser.Education != null ? (int)selectedUser.Education : -1;
            userUpdateForm.DepartmentComboBox.SelectedIndex = selectedUser.Department != null ? (int)selectedUser.Department : -1;
            userUpdateForm.PositionComboBox.SelectedIndex = selectedUser.Position != null ? (int)selectedUser.Position : -1;
            userUpdateForm.StatusComboBox.SelectedIndex = selectedUser.Status != null ? (int)selectedUser.Status : -1;

            userUpdateForm.ShowDialog();
        }

        private async void UserRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedUser = UserDataGrid.SelectedItem as LibUser;
            if (MessageBox.Show("Are you sure you want to remove the following user?\n\n- Name: " + selectedUser.Name + "\n- ID: " + selectedUser.UserId, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    await DisableUserAsync($"api/libusers/{selectedUser.UserId}/disable");

                    userList.Find(x => x.UserId == selectedUser.UserId).Status = LibUser.UserStatus.Inactive;
                    UserDataGrid.ItemsSource = null;
                    UserDataGrid.ItemsSource = userList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UserDataGrid_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            selectedUser = UserDataGrid.SelectedItem as LibUser;
            if (selectedUser != null) UpdateUserSidePanel(selectedUser);
        }
    }
}
