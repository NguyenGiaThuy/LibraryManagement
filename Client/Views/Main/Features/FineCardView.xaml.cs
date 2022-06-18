using Client.Models;
using Client.Views.Main.Features.Dialogs;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
        FineCardDetailsForm fineCardUpdateForm;
        FineCardCreateForm fineCardCreateForm;
        List<LibFineCard> fineCardList;
        LibFineCard selectedFineCard;

        public static async Task<FineCardView> Create()
        {
            var fineCardView = new FineCardView();
            fineCardView.fineCardList = await fineCardView.GetFineCardsAsync($"api/libfinecards");
            fineCardView.FineCardDataGrid.ItemsSource = fineCardView.fineCardList;
            return fineCardView;
        }

        public FineCardView()
        {
            InitializeComponent();

            FineCardDataGrid.Focus();
            fineCardUpdateForm = new FineCardDetailsForm();
            fineCardCreateForm = new FineCardCreateForm();
            fineCardCreateForm.OnFineCardFormSaved += FineCardCreateForm_OnFormSaved;
            fineCardUpdateForm.OnFineCardFormSaved += FineCardUpdateForm_OnFormSaved;
        }

        ~FineCardView()
        {
            fineCardCreateForm.OnFineCardFormSaved -= FineCardCreateForm_OnFormSaved;
            fineCardUpdateForm.OnFineCardFormSaved -= FineCardUpdateForm_OnFormSaved;
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
            LibFineCard fineCard = new LibFineCard();
            var response = await App.Client.PutAsJsonAsync(path, fineCard);
            response.EnsureSuccessStatusCode();
            fineCard = await response.Content.ReadAsAsync<LibFineCard>();
            return fineCard;
        }

        private void FineCardCreateForm_OnFormSaved(LibFineCard fineCard)
        {
            fineCardList.Add(fineCard);
            FineCardDataGrid.ItemsSource = null;
            FineCardDataGrid.ItemsSource = fineCardList;
        }

        private void FineCardUpdateForm_OnFormSaved(LibFineCard fineCard)
        {
            selectedFineCard.CopyFrom(fineCard);
            FineCardDataGrid.ItemsSource = null;
            FineCardDataGrid.ItemsSource = fineCardList;
        }

        private void FineCardNewBtn_Click(object sender, RoutedEventArgs e)
        {
            fineCardCreateForm.CallCardIdTxt.Text = "";

            fineCardCreateForm.ShowDialog();
        }

        private void FineCardUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedFineCard = FineCardDataGrid.SelectedItem as LibFineCard;
            //FineCardIdTxt
            fineCardUpdateForm.FineCardIdTxt.Text = selectedFineCard.FineCardId;
            //ArrearsTxt
            fineCardUpdateForm.ArrearsTxt.Text = selectedFineCard.Arrears.ToString();
            //DaysInArrearsTxt
            fineCardUpdateForm.DaysInArrearsTxt.Text = selectedFineCard.DaysInArrears.ToString();
            //CallCardIdTxt
            fineCardUpdateForm.CallCardIdTxt.Text = selectedFineCard.CallCardId ?? "";
            //ReasonComboBox
            fineCardUpdateForm.ReasonComboBox.Text = selectedFineCard.Reason.ToString();
            //StatusComboBox
            fineCardUpdateForm.StatusComboBox.Text = selectedFineCard.Status.ToString();
            //CreatorIdTxt
            fineCardUpdateForm.CreatorIdTxt.Text = selectedFineCard.CreatorId ?? "";
            //CreatedDateComboBox
            DateTime createdDate = selectedFineCard.CreatedDate != null ? (DateTime)selectedFineCard.CreatedDate : DateTime.MinValue;
            fineCardUpdateForm.CreatedDateComboBox.Text = selectedFineCard.CreatedDate != null ? createdDate.ToString("dd-MM-yyyy") : "";

            fineCardUpdateForm.ShowDialog();
        }

        private async void FineCardRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove the following fineCard?\n\n- Fine Card ID: " + selectedFineCard.FineCardId, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    await CloseFineCardAsync($"api/libfinecards/{selectedFineCard.FineCardId}/close");

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

        private void FineCardDataGrid_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            selectedFineCard = FineCardDataGrid.SelectedItem as LibFineCard;
        }
    }
}
