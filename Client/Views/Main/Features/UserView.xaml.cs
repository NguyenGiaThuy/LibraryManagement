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

        private void UserForm_OnUserFormSaved(LibUser user)
        {
            selectedUser.CopyFrom(user);
            UpdateUserSidePanel(selectedUser);
            UserDataGrid.ItemsSource = null;
            UserDataGrid.ItemsSource = userList;
        }

        private void ClearUserSidePanel()
        {
            UserNameTxt.Text = "";
            DOBTxt.Text = "";
            AddressTxt.Text = "";
            MobileTxt.Text = "";
            EducationTxt.Text = "";
            DepartmentTxt.Text = "";
            PositionTxt.Text = "";
            UserImg.Source = null;
        }

        private void UpdateUserSidePanel(LibUser user)
        {
            UserNameTxt.Text = user.Name;
            DOBTxt.Text = user.Dob.ToString();
            AddressTxt.Text = user.Address;
            MobileTxt.Text = user.Mobile;
            EducationTxt.Text = user.Education.ToString();
            DepartmentTxt.Text = user.Department.ToString();
            PositionTxt.Text = user.Position.ToString();
            try
            {
                UserImg.Source = new BitmapImage(new Uri(user.ImageUrl));
            } catch(Exception) { }
        }

        private void UserNewBtn_Click(object sender, RoutedEventArgs e)
        {

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
            userForm.PasswordTxt.Password = selectedUser.Password;
            //Name
            userForm.NameTxt.Text = selectedUser.Name;
            //Address
            userForm.AddressTxt.Text = selectedUser.Address;
            //DateOfBirth
            DateTime dateOfBirth = (DateTime)selectedUser.Dob;
            userForm.DateOfBirthComboBox.Text = dateOfBirth.ToString();
            //Mobile
            userForm.MobileTxt.Text = selectedUser.Mobile;
            //Education
            userForm.EducationComboBox.Text = selectedUser.Education.ToString();
            //Department
            userForm.DepartmentComboBox.Text = selectedUser.Department.ToString();
            //Position
            userForm.PositionComboBox.Text = selectedUser.Position.ToString();
            //Status
            userForm.StatusComboBox.Text = selectedUser.Status.ToString();

            userForm.ShowDialog();
        }

        private void UserRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedUser = UserDataGrid.SelectedItem as LibUser;
            if (MessageBox.Show("Are you sure you want to remove the following user?\n\n- Name: " + selectedUser.Name + "\n- ID: " + selectedUser.UserId, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                userList.Remove(selectedUser);
                UserDataGrid.ItemsSource = null;
                UserDataGrid.ItemsSource = userList;
                //Update database
                ClearUserSidePanel();
            }
        }

        private void UserDataGrid_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            selectedUser = UserDataGrid.SelectedItem as LibUser;
            if (selectedUser != null)
            {
                UpdateUserSidePanel(selectedUser);
            }
        }
    }
}
