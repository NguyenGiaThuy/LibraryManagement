using Client.Models;
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Views.Main.Features.Dialogs
{
    /// <summary>
    /// Interaction logic for UserForm.xaml
    /// </summary>
    public partial class UserForm : Window
    {
        public Action<LibUser> OnUserFormSaved;

        public UserForm()
        {
            InitializeComponent();
        }

        private async Task<bool> UserExistsAsync(string path)
        {
<<<<<<< HEAD
            bool result = false;
            var response = await App.Client.GetAsync(path);
            if (response.IsSuccessStatusCode) result = true;
            return result;
=======
            LibUser user = new LibUser();

            user.UserId = UserIdTxt.Text;
            user.Password = PasswordTxt.Password;
            user.Name = NameTxt.Text;
            user.Address = AddressTxt.Text;

            DateTime dob;
            if(DateTime.TryParse(DateOfBirthComboBox.Text, out dob)) user.Dob = dob;
            else user.Dob = null;

            user.Mobile = MobileTxt.Text;

            // BUG
            //int education =
            //user.Education = int.TryParse(EducationTxt.Text);


            //user.Department = int.Parse(DepartmentTxt.Text);
            //user.Position = int.Parse(PositionTxt.Text);
            //user.Status = int.Parse(StatusTxt.Text);

            // Update database
            user = await UpdateUserAsync($"api/libusers/{user.UserId}", user);

            OnUserFormSaved?.Invoke(user);

            Hide();
>>>>>>> parent of 17916c3 (Add CreateForms)
        }

        private async Task<string> CreateUserAsync(string path, LibUser user)
        {
            var response = await App.Client.PostAsJsonAsync(path, user);
            response.EnsureSuccessStatusCode();
            string username = await response.Content.ReadAsStringAsync();
            return username;
        }

        private async Task<string> UpdateUserAsync(string path, LibUser user)
        {
            var response = await App.Client.PutAsJsonAsync(path, user);
            response.EnsureSuccessStatusCode();
            string username = await response.Content.ReadAsStringAsync();
            return username;
        }

        private async void UserFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            bool userExists = await UserExistsAsync($"api/libusers/{UserIdTxt.Text.Trim()}");
            LibUser user = new LibUser()
            {
                UserId = UserIdTxt.Text.Trim(),
                Password = PasswordTxt.Password.Trim(),
                Name = NameTxt.Text.Trim(),
                Address = AddressTxt.Text.Trim(),
                Mobile = MobileTxt.Text.Trim(),
                Dob = DateOfBirthComboBox.Text != null ? DateTime.ParseExact(DateOfBirthComboBox.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) : null,
                Education = EducationComboBox.SelectedIndex != -1 ? (LibUser.UserEducation)EducationComboBox.SelectedIndex : null,
                Department = DepartmentComboBox.SelectedIndex != -1 ? (LibUser.UserDepartment)DepartmentComboBox.SelectedIndex : null,
                Position = PositionComboBox.SelectedIndex != -1 ? (LibUser.UserPosition)PositionComboBox.SelectedIndex : null,
                //user.ImageUrl = imageUrlTxt.Text
            };

            switch (userExists)
            {
                case false: // Create user
                    try
                    {
                        await CreateUserAsync($"api/libusers", user);

                        OnUserFormSaved?.Invoke(user);

                        Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case true: // Update user
                    try
                    {
                        await UpdateUserAsync($"api/libusers/{user.UserId}", user);

                        OnUserFormSaved?.Invoke(user);

                        Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            } 
        }

        private void UserFormCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void DateOfBirthComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DateOfBirthComboBox.SelectedItem != null)
            {
                DateTime selectedDate = (DateTime)DateOfBirthCalendar.SelectedDate;
                DateOfBirthComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void DateOfBirthCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)DateOfBirthCalendar.SelectedDate;
            DateOfBirthComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }
    }
}
