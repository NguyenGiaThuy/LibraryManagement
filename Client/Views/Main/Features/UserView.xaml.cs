using Client.Models;
using Client.Views.Main.Features.Dialogs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Client.Views.Main.Features
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>

    public partial class UserView : Window
    {
        UserForm userForm;
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
            userForm = new UserForm();
            userForm.OnUserFormSaved += UserForm_OnUserFormSaved;
        }

        ~UserView()
        {
            userForm.OnUserFormSaved -= UserForm_OnUserFormSaved;
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

        private void UserForm_OnUserFormSaved(LibUser user)
        {
            selectedUser.CopyFrom(user);
            UpdateUserSidePanel(selectedUser);
            UserDataGrid.ItemsSource = null;
            UserDataGrid.ItemsSource = userList;
        }

        //private void ClearUserSidePanel()
        //{
        //    UserNameTxt.Text = "";
        //    DOBTxt.Text = "";
        //    AddressTxt.Text = "";
        //    MobileTxt.Text = "";
        //    EducationTxt.Text = "";
        //    DepartmentTxt.Text = "";
        //    PositionTxt.Text = "";
        //    UserImg.Source = null;
        //}

        private void UpdateUserSidePanel(LibUser user)
        {
            UserNameTxt.Text = user.Name ?? "";
            DOBTxt.Text = user.Dob != null ? user.Dob.ToString() : "";
            AddressTxt.Text = user.Address ?? "";
            MobileTxt.Text = user.Mobile ?? "";
            EducationTxt.Text = user.Education != null ? user.Education.ToString() : "";
            DepartmentTxt.Text = user.Department != null ? user.Department.ToString() : "";
            PositionTxt.Text = user.Position != null ? user.Position.ToString() : "";
            UserImg.Source = user.ImageUrl != null ? new BitmapImage(new Uri(user.ImageUrl)) : null;
        }

        private void UserNewBtn_Click(object sender, RoutedEventArgs e)
        {
            userForm.Title = "Create Form";
            userForm.UserFormTitleTxt.Text = "TẠO NHÂN VIÊN";
            //UserId
            userForm.UserIdTxt.IsEnabled = true;
            //Password
            userForm.PasswordTxt.IsEnabled = true;
            //Status
            userForm.StatusComboBox.IsEnabled = false;

            userForm.ShowDialog();
        }

        private void UserUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedUser = UserDataGrid.SelectedItem as LibUser;
            //userForm description
            userForm.Title = "Update Form";
            userForm.UserFormTitleTxt.Text = "CẬP NHẬT NHÂN VIÊN";
            //UserId
            userForm.UserIdTxt.IsEnabled = false;
            userForm.UserIdTxt.Text = selectedUser.UserId;
            //Password
            userForm.PasswordTxt.IsEnabled = false;
            userForm.PasswordTxt.Password = selectedUser.Password;
            //Name
            userForm.NameTxt.Text = selectedUser.Name ?? "";
            //Address
            userForm.AddressTxt.Text = selectedUser.Address ?? "";
            //DateOfBirth
<<<<<<< HEAD
            DateTime dateOfBirth = selectedUser.Dob != null ? (DateTime)selectedUser.Dob : DateTime.MinValue;
            userForm.DateOfBirthComboBox.Text = selectedUser.Dob != null ? dateOfBirth.ToString("dd-MM-yyyy") : "";
=======
            DateTime dateOfBirth = (DateTime)selectedUser.Dob;
            userForm.DateOfBirthComboBox.Text = dateOfBirth.ToString();
<<<<<<< HEAD
>>>>>>> parent of 17916c3 (Add CreateForms)
=======
>>>>>>> parent of 17916c3 (Add CreateForms)
            //Mobile
            userForm.MobileTxt.Text = selectedUser.Mobile ?? "";
            //Education
            userForm.EducationComboBox.SelectedIndex = selectedUser.Education != null ? (int)selectedUser.Education : -1;
            //Department
            userForm.DepartmentComboBox.SelectedIndex = selectedUser.Department != null ? (int)selectedUser.Department : -1;
            //Position
            userForm.PositionComboBox.SelectedIndex = selectedUser.Position != null ? (int)selectedUser.Position : -1;
            //Status
            userForm.StatusComboBox.IsEnabled = false;
            userForm.StatusComboBox.SelectedIndex = selectedUser.Status != null ? (int)selectedUser.Status : -1;

            userForm.ShowDialog();
        }

        private async void UserRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedUser = UserDataGrid.SelectedItem as LibUser;
            if (MessageBox.Show("Are you sure you want to remove the following user?\n\n- Name: " +
                selectedUser.Name + "\n- ID: " +
                selectedUser.UserId, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
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
