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
    /// Interaction logic for FineCardCreateForm.xaml
    /// </summary>
    public partial class FineCardCreateForm : Window
    {
        public Action<LibFineCard> OnFineCardFormSaved;

        public FineCardCreateForm()
        {
            InitializeComponent();
        }

        private async Task<LibFineCard> CreateFineCardAsync(string path, LibFineCard fineCard) {
            var response = await App.Client.PostAsJsonAsync(path, fineCard);
            response.EnsureSuccessStatusCode();
            fineCard = await response.Content.ReadAsAsync<LibFineCard>();
            return fineCard;
        }

        private async void FineCardCreateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try {
                LibFineCard fineCard = new LibFineCard() {
                    //FineCardId =
                    //Arrears = 
                    //DaysInArrears = 
                    CallCardId = CallCardIdTxt.Text.Trim(),
                    //Status =
                    CreatorId = CreatorIdTxt.Text.Trim(),
                    //CreatedDate =
                };

                OnFineCardFormSaved?.Invoke(await CreateFineCardAsync($"api/libfinecards", fineCard));

                Hide();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void FineCardCreateFormCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
