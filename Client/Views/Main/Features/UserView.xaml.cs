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
using Microsoft.Win32;
using System.Diagnostics;
using System.Globalization;
using Client;
using Client.Models;
using Client.Views.Main.Features.Dialogs;

namespace Client.Views.Main.Features {
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    
    public partial class UserView : Window {
        UserForm userForm;
        List<LibUser> userList;
        LibUser selectedUser;

        public UserView() {
            InitializeComponent();

            UserDataGrid.Focus();
            //Get users from database
            userList = new List<LibUser>();
            userList.Add(new LibUser("990292", "afs(#093", "Tom Hanks", "CA, USA", new DateTime(1970, 12, 07), "0393908786", 1, 1, 1, "TomHanks.jpg"));
            userList.Add(new LibUser("937202", "34g34g(!", "Tom Cruise", "CA, USA", new DateTime(1930, 7, 24), "0978364259", 1, 1, 1, "TomCruise.jpg"));
            userList.Add(new LibUser("908840", "%(*sdf24", "Tom Holland", "CA, USA", new DateTime(1912, 4, 11), "0867325659", 1, 1, 1, "TomHolland.jpg"));
            UserDataGrid.ItemsSource = userList;

            userForm = new UserForm();
            userForm.OnUserFormSaved += UserForm_OnUserFormSaved;
        }

        ~UserView() {
            userForm.OnUserFormSaved -= UserForm_OnUserFormSaved;
        }

        private void UserForm_OnUserFormSaved(LibUser user) {
            selectedUser.CopyFrom(user);
            UpdateUserSidePanel(selectedUser);
            UserDataGrid.ItemsSource = null;
            UserDataGrid.ItemsSource = userList;
        }

        private void ClearUserSidePanel() {
            UserNameTxt.Text = "";
            IDTxt.Text = "";
            DOBTxt.Text = "";
            AddressTxt.Text = "";
            MobileTxt.Text = "";
            EducationTxt.Text = "";
            DepartmentTxt.Text = "";
            PositionTxt.Text = "";
            UserImg.Source = null;
        }

        private void UpdateUserSidePanel(LibUser user) {
            UserNameTxt.Text = user.Name;
            IDTxt.Text = user.UserId;
            DOBTxt.Text = user.Dob.ToString();
            AddressTxt.Text = user.Address;
            MobileTxt.Text = user.Mobile;
            EducationTxt.Text = user.Education.ToString();
            DepartmentTxt.Text = user.Department.ToString();
            PositionTxt.Text = user.Position.ToString();
            UserImg.Source = new BitmapImage(new Uri("pack://application:,,,/Client;component/Assets/Images/Users/" + user.ImageUrl));
        }

        private void UserNewBtn_Click(object sender, RoutedEventArgs e) {
            
        }

        private void UserUpdateBtn_Click(object sender, RoutedEventArgs e) {
            selectedUser = UserDataGrid.SelectedItem as LibUser;

            userForm.Title = "Update Form";
            userForm.UserFormTitleTxt.Text = "UPDATE THE USER";
            userForm.UserIdTxt.IsEnabled = false;
            userForm.UserIdTxt.Text = selectedUser.UserId;
            userForm.PasswordTxt.Password = selectedUser.Password;
            userForm.NameTxt.Text = selectedUser.Name;
            userForm.AddressTxt.Text = selectedUser.Address;
            userForm.DateOfBirthTxt.Text = selectedUser.Dob.ToString();
            userForm.MobileTxt.Text = selectedUser.Mobile;
            userForm.EducationTxt.Text = selectedUser.Education.ToString();
            userForm.DepartmentTxt.Text = selectedUser.Department.ToString();
            userForm.PositionTxt.Text = selectedUser.Position.ToString();
            userForm.StatusTxt.Text = selectedUser.Status.ToString();

            userForm.ShowDialog();
        }

        private void UserRemoveBtn_Click(object sender, RoutedEventArgs e) {
            selectedUser = UserDataGrid.SelectedItem as LibUser;
            if (MessageBox.Show("Are you sure you want to remove the following user?\n\n- Name: " + selectedUser.Name + "\n- ID: " + selectedUser.UserId, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) {
                userList.Remove(selectedUser);
                UserDataGrid.ItemsSource = null;
                UserDataGrid.ItemsSource = userList;
                //Update database
                ClearUserSidePanel();
            }
        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectedUser = UserDataGrid.SelectedItem as LibUser;
            if (selectedUser != null) {
                UpdateUserSidePanel(selectedUser);
            }
        }
    }
}
