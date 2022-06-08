using Client.Models;
using Client.Views.Main.Features.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Client.Views.Main.Features
{
    /// <summary>
    /// Interaction logic for FineCardView.xaml
    /// </summary>
    public partial class FineCardView : Window
    {
        FineCardForm fineCardForm;
        List<LibFineCard> fineCardList;
        LibFineCard selectedFineCard;

        public FineCardView()
        {
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

        ~FineCardView()
        {
            fineCardForm.OnFineCardFormSaved -= FineCardForm_OnFineCardFormSaved;
        }

        private void FineCardForm_OnFineCardFormSaved(LibFineCard fineCard)
        {
            selectedFineCard.CopyFrom(fineCard);
            FineCardDataGrid.ItemsSource = null;
            FineCardDataGrid.ItemsSource = fineCardList;
        }

        private void FineCardNewBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void FineCardUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedFineCard = FineCardDataGrid.SelectedItem as LibFineCard;
            //fineCardForm description
            fineCardForm.Title = "Update Form";
            fineCardForm.FineCardFormTitleTxt.Text = "CẬP NHẬT PHIẾU PHẠT";
            //FineCardId
            fineCardForm.FineCardIdTxt.IsEnabled = false;
            fineCardForm.FineCardIdTxt.Text = selectedFineCard.FineCardId;
            //Arrears
            fineCardForm.ArrearsTxt.IsEnabled = false;
            fineCardForm.ArrearsTxt.Text = selectedFineCard.Arrears.ToString();
            //DaysInArrears
            fineCardForm.DaysInArrearsTxt.IsEnabled = false;
            fineCardForm.DaysInArrearsTxt.Text = selectedFineCard.DaysInArrears.ToString();
            //CallCardId
            fineCardForm.CallCardIdTxt.Text = selectedFineCard.CallCardId;
            //Reason
            fineCardForm.ReasonComboBox.IsEnabled = false;
            fineCardForm.ReasonComboBox.Text = selectedFineCard.Reason.ToString();
            //Status
            fineCardForm.StatusComboBox.IsEnabled = false;
            fineCardForm.StatusComboBox.Text = selectedFineCard.Status.ToString();
            //CreatorId
            fineCardForm.CreatorIdTxt.Text = selectedFineCard.CreatorId;
            //CreatedDate
            fineCardForm.CreatedDateComboBox.IsEnabled=false;
            DateTime createdDate = (DateTime)selectedFineCard.CreatedDate;
            fineCardForm.CreatedDateComboBox.Text = createdDate.ToString("dd-MM-yyyy");

            fineCardForm.ShowDialog();
        }

        private void FineCardRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedFineCard = FineCardDataGrid.SelectedItem as LibFineCard;
            if (MessageBox.Show("Are you sure you want to remove the following fineCard?\n\n- Fine Card ID: " + selectedFineCard.FineCardId, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                fineCardList.Remove(selectedFineCard);
                FineCardDataGrid.ItemsSource = null;
                FineCardDataGrid.ItemsSource = fineCardList;
                //Update database
            }
        }
    }
}
