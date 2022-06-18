using Client.Models;
using Client.Views.Main.Features.Dialogs;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Client.Views.Main.Features
{
    /// <summary>
    /// Interaction logic for CallCardView.xaml
    /// </summary>
    public partial class CallCardView : Window
    {
        CallCardDetailsForm callCardDetailsForm;
        CallCardCreateForm callCardCreateForm;
        CallCardUpdateForm callCardUpdateForm;
        List<LibCallCard> callCardList;
        LibCallCard selectedCallCard;

        public static async Task<CallCardView> Create() {
            var callCardView = new CallCardView();
            callCardView.callCardList = await callCardView.GetCallCardsAsync($"api/libcallcards");
            callCardView.CallCardDataGrid.ItemsSource = callCardView.callCardList;
            return callCardView;
        }

        public CallCardView()
        {
            InitializeComponent();

            CallCardDataGrid.Focus();
            callCardDetailsForm = new CallCardDetailsForm();
            callCardCreateForm = new CallCardCreateForm();
            callCardUpdateForm = new CallCardUpdateForm();
            callCardCreateForm.OnCallCardFormSaved += CallCardCreateForm_OnFormSaved;
            callCardUpdateForm.OnCallCardFormSaved += CallCardUpdateForm_OnFormSaved;
        }

        ~CallCardView()
        {
            callCardCreateForm.OnCallCardFormSaved -= CallCardCreateForm_OnFormSaved;
            callCardUpdateForm.OnCallCardFormSaved -= CallCardUpdateForm_OnFormSaved;
        }

        private async Task<List<LibCallCard>> GetCallCardsAsync(string path) {
            List<LibCallCard> callCards = null;
            var response = await App.Client.GetAsync(path);
            if (response.IsSuccessStatusCode) callCards = await response.Content.ReadAsAsync<List<LibCallCard>>();
            return callCards;
        }

        //private async Task<LibCallCard> UpdateCallCardStatusAsync(string path)
        //{
        //    LibCallCard callCard = new LibCallCard();
        //    var response = await App.Client.PutAsJsonAsync(path, callCard);
        //    response.EnsureSuccessStatusCode();
        //    callCard = await response.Content.ReadAsAsync<LibCallCard>();
        //    return callCard;
        //}

        private void CallCardCreateForm_OnFormSaved(LibCallCard callCard)
        {
            callCardList.Add(callCard);
            CallCardDataGrid.ItemsSource = null;
            CallCardDataGrid.ItemsSource = callCardList;
        }

        private void CallCardUpdateForm_OnFormSaved(LibCallCard callCard)
        {
            selectedCallCard.CopyFrom(callCard);
            CallCardDataGrid.ItemsSource = null;
            CallCardDataGrid.ItemsSource = callCardList;
        }

        private void CallCardNewBtn_Click(object sender, RoutedEventArgs e)
        {
            callCardCreateForm.DueDateComboBox.Text = "";
            callCardCreateForm.BookIdTxt.Text = "";
            callCardCreateForm.MembershipIdTxt.Text = "";
            callCardCreateForm.CreatorIdTxt.Text = "";

            callCardCreateForm.ShowDialog();
        }

        private void CallCardDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedCallCard = CallCardDataGrid.SelectedItem as LibCallCard;
            //CallCardIdTxt
            callCardDetailsForm.CallCardIdTxt.Text = selectedCallCard.CallCardId;
            //DueDateComboBox
            DateTime dueDate = selectedCallCard.DueDate != null ? (DateTime)selectedCallCard.DueDate : DateTime.MinValue;
            callCardDetailsForm.DueDateComboBox.Text = selectedCallCard.DueDate != null ? dueDate.ToString("dd-MM-yyyy") : "";
            //BookIdTxt
            callCardDetailsForm.BookIdTxt.Text = selectedCallCard.BookId.ToString();
            //MembershipIdTxt
            callCardDetailsForm.MembershipIdTxt.Text = selectedCallCard.MembershipId ?? "";
            //StatusComboBox
            callCardDetailsForm.StatusComboBox.Text = selectedCallCard.State.ToString();
            //CreatorIdTxt
            callCardDetailsForm.CreatorIdTxt.Text = selectedCallCard.CreatorId ?? "";
            //CreatedDateComboBox
            DateTime createdDate = selectedCallCard.CreatedDate != null ? (DateTime)selectedCallCard.CreatedDate : DateTime.MinValue;
            callCardDetailsForm.CreatedDateComboBox.Text = selectedCallCard.CreatedDate != null ? createdDate.ToString("dd-MM-yyyy") : "";

            callCardDetailsForm.ShowDialog();
        }
    }
}
