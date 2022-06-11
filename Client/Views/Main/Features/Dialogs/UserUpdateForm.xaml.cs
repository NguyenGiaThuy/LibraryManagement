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
    public partial class UserUpdateForm : Window
    {
        public Action<LibUser> OnUserFormSaved;

        public UserUpdateForm()
        {
            InitializeComponent();
        }

        private async Task<LibUser> UpdateUserAsync(string path, LibUser user)
        {
            var response = await App.Client.PutAsJsonAsync(path, user);
            response.EnsureSuccessStatusCode();
            user = await response.Content.ReadAsAsync<LibUser>();
            return user;
        }

        private async void UserUpdateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
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
                ImageUrl = ImgTxt.Text.Trim(),
            };

            try
            {
                OnUserFormSaved?.Invoke(await UpdateUserAsync($"api/libusers/{user.UserId}", user));

                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
