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
    /// Interaction logic for FineCardUpdateForm.xaml
    /// </summary>
    public partial class FineCardDetailsForm : Window
    {
        public Action<LibFineCard> OnFineCardFormSaved;

        public FineCardDetailsForm()
        {
            InitializeComponent();
        }

        private async Task<LibFineCard> CreateFineCardAsync(string path, LibFineCard fineCard) {
            var response = await App.Client.PostAsJsonAsync(path, fineCard);
            response.EnsureSuccessStatusCode();
            fineCard = await response.Content.ReadAsAsync<LibFineCard>();
            return fineCard;
        }

        private async void FineCardUpdateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try {
                LibFineCard fineCard = new LibFineCard() {
                    FineCardId = FineCardIdTxt.Text.Trim(),
                    Arrears = int.Parse(ArrearsTxt.Text.Trim()),
                    DaysInArrears = int.Parse(DaysInArrearsTxt.Text.Trim()),
                    CallCardId = CallCardIdTxt.Text.Trim(),
                    Reason = ReasonComboBox.SelectedIndex != -1 ? (LibFineCard.FineCardReason)ReasonComboBox.SelectedIndex : null,
                    Status = StatusComboBox.SelectedIndex != -1 ? (LibFineCard.FineCardStatus)StatusComboBox.SelectedIndex : null,
                    CreatorId = CreatorIdTxt.Text.Trim(),
                    CreatedDate = CreatedDateComboBox.Text.Trim() != "" ? DateTime.ParseExact(CreatedDateComboBox.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) : null,
                };

                OnFineCardFormSaved?.Invoke(await CreateFineCardAsync($"api/libfinecards", fineCard));

                Hide();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void FineCardUpdateFormCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void CreatedDateComboBox_LostFocus(object sender, RoutedEventArgs e)
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

        private void FineCardDetailsFormCloseBtn_Click(object sender, RoutedEventArgs e) {

        }
    }
}
