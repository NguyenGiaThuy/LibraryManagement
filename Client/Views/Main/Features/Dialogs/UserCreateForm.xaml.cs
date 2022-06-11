using Client.Models;
using System;
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
        public Action<LibUser> OnUserCreateFormSaved;

        public UserCreateForm()
        {
            InitializeComponent();
        }
        private async void UserCreateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            LibUser user = new LibUser();

            user.UserId = UserIdTxt.Text;
            user.Password = PasswordTxt.Password;
            user.Name = NameTxt.Text;
            user.Address = AddressTxt.Text;

            DateTime dob;
            if(DateTime.TryParse(DateOfBirthComboBox.Text, out dob)) 
                user.Dob = dob;
            else 
                user.Dob = null;

            user.Mobile = MobileTxt.Text;

            // BUG
            //int education =
            //user.Education = int.TryParse(EducationTxt.Text);


            //user.Department = int.Parse(DepartmentTxt.Text);
            //user.Position = int.Parse(PositionTxt.Text);
            //user.Status = int.Parse(StatusTxt.Text);

            // Update database
            user = await UpdateUserAsync($"api/libusers/{user.UserId}", user);

            OnUserCreateFormSaved?.Invoke(user);

            Hide();
        }

        private async Task<LibUser> UpdateUserAsync(string path, LibUser user)
        {
            var response = await App.Client.PutAsJsonAsync(path, user);
            response.EnsureSuccessStatusCode();
            user = await response.Content.ReadAsAsync<LibUser>();
            return user;
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

        private void DateOfBirthComboBox_LostFocus(object sender, RoutedEventArgs e) {
            if (DateOfBirthComboBox.SelectedItem != null) {
                DateTime selectedDate = (DateTime)DateOfBirthCalendar.SelectedDate;
                DateOfBirthComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void DateOfBirthCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            DateTime selectedDate = (DateTime)DateOfBirthCalendar.SelectedDate;
            DateOfBirthComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }
    }
}
