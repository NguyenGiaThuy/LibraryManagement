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
    /// Interaction logic for UserCreateForm.xaml
    /// </summary>
    public partial class UserCreateForm : Window
    {
        public Action<LibUser> OnUserFormSaved;

        public UserCreateForm()
        {
            InitializeComponent();
        }

        private async Task<LibUser> CreateUserAsync(string path, LibUser user)
        {
            var response = await App.Client.PostAsJsonAsync(path, user);
            response.EnsureSuccessStatusCode();
            user = await response.Content.ReadAsAsync<LibUser>();
            return user;
        }

        private async void UserCreateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LibUser user = new LibUser()
                {
                    UserId = UserIdTxt.Text.Trim(),
                    Password = PasswordTxt.Password.Trim(),
                    Name = NameTxt.Text.Trim(),
                    Address = AddressTxt.Text.Trim(),
                    Mobile = MobileTxt.Text.Trim(),
                    Dob = DateOfBirthComboBox.Text.Trim() != "" ? DateTime.ParseExact(DateOfBirthComboBox.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) : null,
                    Education = EducationComboBox.SelectedIndex != -1 ? (LibUser.UserEducation)EducationComboBox.SelectedIndex : null,
                    Department = DepartmentComboBox.SelectedIndex != -1 ? (LibUser.UserDepartment)DepartmentComboBox.SelectedIndex : null,
                    Position = PositionComboBox.SelectedIndex != -1 ? (LibUser.UserPosition)PositionComboBox.SelectedIndex : null,
                    ImageUrl = ImgTxt.Text
                };

                OnUserFormSaved?.Invoke(await CreateUserAsync($"api/libusers", user));

                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserCreateFormCancelBtn_Click(object sender, RoutedEventArgs e)
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
