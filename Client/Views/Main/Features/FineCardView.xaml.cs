using Client.Models;
using Client.Views.Main.Features.Dialogs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Client.Views.Main.Features
{
    /// <summary>
    /// Interaction logic for FineCardView.xaml
    /// </summary>
    public partial class FineCardView : Window
    {
        FineCardDetailsForm fineCardDetailsForm;
        FineCardCreateForm fineCardCreateForm;
        List<LibFineCard> fineCardList;
        LibFineCard selectedFineCard;

        public static async Task<FineCardView> Create()
        {
            var fineCardView = new FineCardView();
            fineCardView.fineCardList = await fineCardView.GetFineCardsAsync($"api/libfinecards");

            // Update arrears
            foreach (var fineCard in fineCardView.fineCardList) fineCardView.UpdateFineCardArrearsAsync($"api/libfinecards/{fineCard.FineCardId}");

            fineCardView.FineCardDataGrid.ItemsSource = fineCardView.fineCardList;
            return fineCardView;
        }

        public FineCardView()
        {
            InitializeComponent();

            FineCardDataGrid.Focus();
            fineCardDetailsForm = new FineCardDetailsForm();
            fineCardCreateForm = new FineCardCreateForm();
            fineCardCreateForm.OnFineCardFormSaved += FineCardCreateForm_OnFormSaved;
        }

        ~FineCardView()
        {
            fineCardCreateForm.OnFineCardFormSaved -= FineCardCreateForm_OnFormSaved;
        }

        private async Task<LibFineCard> UpdateFineCardArrearsAsync(string path)
        {
            LibFineCard fineCard = new LibFineCard();
            var response = await App.Client.PutAsJsonAsync(path, fineCard);
            if (response.IsSuccessStatusCode) fineCard = await response.Content.ReadAsAsync<LibFineCard>();
            return fineCard;
        }

        private async Task<List<LibFineCard>> GetFineCardsAsync(string path)
        {
            List<LibFineCard> fineCards = null;
            var response = await App.Client.GetAsync(path);
            if (response.IsSuccessStatusCode) fineCards = await response.Content.ReadAsAsync<List<LibFineCard>>();
            return fineCards;
        }

        private async Task<LibFineCard> CloseFineCardAsync(string path)
        {
            var response = await App.Client.DeleteAsync(path);
            response.EnsureSuccessStatusCode();
            var fineCard = await response.Content.ReadAsAsync<LibFineCard>();
            return fineCard;
        }

        private void FineCardCreateForm_OnFormSaved(LibFineCard fineCard)
        {
            fineCardList.Add(fineCard);
            FineCardDataGrid.ItemsSource = null;
            FineCardDataGrid.ItemsSource = fineCardList;
        }

        private void FineCardNewBtn_Click(object sender, RoutedEventArgs e)
        {
            fineCardCreateForm.CallCardIdTxt.Text = "";
            fineCardCreateForm.CreatorIdTxt.Text = "";

            fineCardCreateForm.ShowDialog();
        }

        private void FineCardDatailsBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedFineCard = FineCardDataGrid.SelectedItem as LibFineCard;
            //FineCardIdTxt
            fineCardDetailsForm.FineCardIdTxt.Text = selectedFineCard.FineCardId;
            //ArrearsTxt
            fineCardDetailsForm.ArrearsTxt.Text = selectedFineCard.Arrears.ToString();
            //DaysInArrearsTxt
            fineCardDetailsForm.DaysInArrearsTxt.Text = selectedFineCard.DaysInArrears.ToString();
            //CallCardIdTxt
            fineCardDetailsForm.CallCardIdTxt.Text = selectedFineCard.CallCardId ?? "";
            //ReasonComboBox
            fineCardDetailsForm.ReasonComboBox.Text = selectedFineCard.Reason.ToString();
            //StatusComboBox
            fineCardDetailsForm.StatusComboBox.Text = selectedFineCard.Status.ToString();
            //CreatorIdTxt
            fineCardDetailsForm.CreatorIdTxt.Text = selectedFineCard.CreatorId ?? "";
            //CreatedDateComboBox
            DateTime createdDate = selectedFineCard.CreatedDate != null ? (DateTime)selectedFineCard.CreatedDate : DateTime.MinValue;
            fineCardDetailsForm.CreatedDateComboBox.Text = selectedFineCard.CreatedDate != null ? createdDate.ToString("dd-MM-yyyy") : "";

            fineCardDetailsForm.ShowDialog();
        }

        private async void FineCardRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to mark the following fineCard as paid?\n\n- Fine Card ID: " + selectedFineCard.FineCardId, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    await CloseFineCardAsync($"api/libfinecards/{selectedFineCard.FineCardId}");

                    fineCardList.Find(x => x.FineCardId == selectedFineCard.FineCardId).Status = LibFineCard.FineCardStatus.Paid;
                    FineCardDataGrid.ItemsSource = null;
                    FineCardDataGrid.ItemsSource = fineCardList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
