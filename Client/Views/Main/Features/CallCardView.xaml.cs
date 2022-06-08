using Client.Models;
using Client.Views.Main.Features.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Client.Views.Main.Features
{
    /// <summary>
    /// Interaction logic for CallCardView.xaml
    /// </summary>
    public partial class CallCardView : Window
    {
        CallCardForm callCardForm;
        List<LibCallCard> callCardList;
        LibCallCard selectedCallCard;

        public CallCardView()
        {
            InitializeComponent();

            CallCardDataGrid.Focus();
            //Get callCards from database
            callCardList = new List<LibCallCard>();
            callCardList.Add(new LibCallCard("098209", new DateTime(2018, 08, 12), "393822", "207935"));
            callCardList.Add(new LibCallCard("094682", new DateTime(2016, 12, 03), "393485", "237785"));
            callCardList.Add(new LibCallCard("091385", new DateTime(2019, 05, 08), "345831", "203124"));
            CallCardDataGrid.ItemsSource = callCardList;

            callCardForm = new CallCardForm();
            callCardForm.OnCallCardFormSaved += CallCardForm_OnCallCardFormSaved;
        }

        ~CallCardView()
        {
            callCardForm.OnCallCardFormSaved -= CallCardForm_OnCallCardFormSaved;
        }

        private void CallCardForm_OnCallCardFormSaved(LibCallCard callCard)
        {
            selectedCallCard.CopyFrom(callCard);
            CallCardDataGrid.ItemsSource = null;
            CallCardDataGrid.ItemsSource = callCardList;
        }

        private void CallCardNewBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CallCardUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedCallCard = CallCardDataGrid.SelectedItem as LibCallCard;
            //callCardForm description
            callCardForm.Title = "Update Form";
            callCardForm.CallCardFormTitleTxt.Text = "CẬP NHẬT PHIẾU MƯỢN SÁCH";
            //CallCardId
            callCardForm.CallCardIdTxt.IsEnabled = false;
            callCardForm.CallCardIdTxt.Text = selectedCallCard.CallCardId;
            //DueDate
            DateTime dueDate = (DateTime)selectedCallCard.DueDate;
            callCardForm.DueDateComboBox.Text = dueDate.ToString("dd-MM-yyyy");
            //BookId
            callCardForm.BookIdTxt.IsEnabled = false;
            callCardForm.BookIdTxt.Text = selectedCallCard.BookId.ToString();
            //Membership
            callCardForm.MembershipIdTxt.Text = selectedCallCard.MembershipId;
            //Status
            callCardForm.StatusComboBox.IsEnabled = false;
            callCardForm.StatusComboBox.Text = selectedCallCard.Status.ToString();
            //Creator
            callCardForm.CreatorIdTxt.Text = selectedCallCard.CreatorId;
            //CreatedDate
            callCardForm.CreatedDateComboBox.IsEnabled = false;
            DateTime createdDate = (DateTime)selectedCallCard.DueDate;
            callCardForm.CreatedDateComboBox.Text = createdDate.ToString("dd-MM-yyyy");

            callCardForm.ShowDialog();
        }

        private void CallCardRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedCallCard = CallCardDataGrid.SelectedItem as LibCallCard;
            if (MessageBox.Show("Are you sure you want to remove the following callCard?\n\n- Call Card ID: " + selectedCallCard.CallCardId, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                callCardList.Remove(selectedCallCard);
                CallCardDataGrid.ItemsSource = null;
                CallCardDataGrid.ItemsSource = callCardList;
                //Update database
            }
        }
    }
}
