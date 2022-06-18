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
    /// Interaction logic for CallCardUpdateForm.xaml
    /// </summary>
    public partial class CallCardDetailsForm : Window
    {
        public Action<LibCallCard> OnCallCardFormSaved;

        public CallCardDetailsForm()
        {
            InitializeComponent();
        }

        private async Task<LibCallCard> UpdateCallCardAsync(string path, LibCallCard callcard) {
            var response = await App.Client.PutAsJsonAsync(path, callcard);
            response.EnsureSuccessStatusCode();
            callcard = await response.Content.ReadAsAsync<LibCallCard>();
            return callcard;
        }

        private async void CallCardUpdateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try {
                LibCallCard callCard = new LibCallCard() {
                    CallCardId = CallCardIdTxt.Text.Trim(),
                    DueDate = DueDateComboBox.Text.Trim() != "" ? DateTime.ParseExact(DueDateComboBox.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) : null,
                    BookId = BookIdTxt.Text.Trim(),
                    MembershipId = MembershipIdTxt.Text.Trim(),
                    Status = StatusComboBox.SelectedIndex != -1 ? (LibCallCard.CallCardStatus)StatusComboBox.SelectedIndex : null,
                    CreatorId = CreatorIdTxt.Text.Trim(),
                    CreatedDate = CreatedDateComboBox.Text.Trim() != "" ? DateTime.ParseExact(CreatedDateComboBox.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) : null,
                };

                OnCallCardFormSaved?.Invoke(await UpdateCallCardAsync($"api/libcallCards/{callCard.CallCardId}", callCard));

                Hide();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void CallCardDetailsFormCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void DueDateComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DueDateComboBox.SelectedItem != null)
            {
                DateTime selectedDate = (DateTime)DueDateCalendar.SelectedDate;
                DueDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void DueDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)DueDateCalendar.SelectedDate;
            DueDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }

        private void CreatedDateTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CreatedDateComboBox.SelectedItem != null)
            {
                DateTime selectedDate = (DateTime)CreatedDateCalendar.SelectedDate;
                CreatedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void CreatedDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)CreatedDateCalendar.SelectedDate;
            CreatedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }
    }
}
