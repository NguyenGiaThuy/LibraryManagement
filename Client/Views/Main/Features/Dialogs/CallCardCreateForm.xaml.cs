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
    /// Interaction logic for CallCardCreateForm.xaml
    /// </summary>
    public partial class CallCardCreateForm : Window
    {
        public Action<LibCallCard> OnCallCardFormSaved;

        public CallCardCreateForm()
        {
            InitializeComponent();
        }

        private async Task<LibCallCard> CreateCallCardAsync(string path, LibCallCard callCard) {
            var response = await App.Client.PostAsJsonAsync(path, callCard);
            response.EnsureSuccessStatusCode();
            callCard = await response.Content.ReadAsAsync<LibCallCard>();
            return callCard;
        }

        private async void CallCardCreateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try {
                LibCallCard callCard = new LibCallCard() {
                    //CallCardId =
                    DueDate = DueDateComboBox.Text.Trim() != "" ? DateTime.ParseExact(DueDateComboBox.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) : null,
                    BookId = BookIdTxt.Text.Trim(),
                    MembershipId = MembershipIdTxt.Text.Trim(),
                    //Status = 
                    //CreatorId = CreatorIdTxt.Text.Trim(),
                    //CreatedDate =
                };

                OnCallCardFormSaved?.Invoke(await CreateCallCardAsync($"api/libcallcards", callCard));

                Hide();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void CallCardCreateFormCancelBtn_Click(object sender, RoutedEventArgs e)
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
    }
}
