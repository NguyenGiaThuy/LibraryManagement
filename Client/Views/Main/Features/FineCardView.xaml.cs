using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Diagnostics;
using System.Globalization;
using Client;
using Client.Models;
using Client.Views.Main.Features.Dialogs;

namespace Client.Views.Main.Features {
    /// <summary>
    /// Interaction logic for FineCardView.xaml
    /// </summary>
    public partial class FineCardView : Window {
        FineCardForm fineCardForm;
        List<LibFineCard> fineCardList;
        LibFineCard selectedFineCard;

        public FineCardView() {
            InitializeComponent();

            FineCardDataGrid.Focus();
            //Get fineCards from database
            fineCardList = new List<LibFineCard>();
            fineCardList.Add(new LibFineCard("334672", "962749"));
            fineCardList.Add(new LibFineCard("333850", "907731"));
            fineCardList.Add(new LibFineCard("313758", "907064"));
            FineCardDataGrid.ItemsSource = fineCardList;

            fineCardForm = new FineCardForm();
            fineCardForm.OnFineCardFormSaved += FineCardForm_OnFineCardFormSaved;
        }

        ~FineCardView() {
            fineCardForm.OnFineCardFormSaved -= FineCardForm_OnFineCardFormSaved;
        }

        private void FineCardForm_OnFineCardFormSaved(LibFineCard fineCard) {
            selectedFineCard.CopyFrom(fineCard);
            FineCardDataGrid.ItemsSource = null;
            FineCardDataGrid.ItemsSource = fineCardList;
        }

        private void FineCardNewBtn_Click(object sender, RoutedEventArgs e) {
        }

        private void FineCardUpdateBtn_Click(object sender, RoutedEventArgs e) {
            selectedFineCard = FineCardDataGrid.SelectedItem as LibFineCard;

            fineCardForm.Title = "Update Form";
            fineCardForm.FineCardFormTitleTxt.Text = "UPDATE THE FINE CARD";
            fineCardForm.FineCardIdTxt.IsEnabled = false;
            fineCardForm.FineCardIdTxt.Text = selectedFineCard.FineCardId;
            fineCardForm.ArrearsTxt.IsEnabled = false;
            fineCardForm.ArrearsTxt.Text = selectedFineCard.Arrears.ToString();
            fineCardForm.DaysInArrearsTxt.IsEnabled = false;
            fineCardForm.DaysInArrearsTxt.Text = selectedFineCard.DaysInArrears.ToString();
            fineCardForm.CallCardIdTxt.Text = selectedFineCard.CallCardId;
            fineCardForm.ReasonTxt.IsEnabled = false;
            fineCardForm.ReasonTxt.Text = selectedFineCard.Reason.ToString();
            fineCardForm.StatusTxt.IsEnabled = false;
            fineCardForm.StatusTxt.Text = selectedFineCard.Status.ToString();
            fineCardForm.CreatorIdTxt.Text = selectedFineCard.CreatorId;
            fineCardForm.CreatedDateTxt.IsEnabled=false;
            fineCardForm.CreatedDateTxt.Text = selectedFineCard.CreatedDate.ToString();

            fineCardForm.ShowDialog();
        }

        private void FineCardRemoveBtn_Click(object sender, RoutedEventArgs e) {
            selectedFineCard = FineCardDataGrid.SelectedItem as LibFineCard;
            if (MessageBox.Show("Are you sure you want to remove the following fineCard?\n\n- Fine Card ID: " + selectedFineCard.FineCardId, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) {
                fineCardList.Remove(selectedFineCard);
                FineCardDataGrid.ItemsSource = null;
                FineCardDataGrid.ItemsSource = fineCardList;
                //Update database
            }
        }
    }
}
