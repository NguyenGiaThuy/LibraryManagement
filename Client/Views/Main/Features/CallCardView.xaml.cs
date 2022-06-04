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
    /// Interaction logic for CallCardView.xaml
    /// </summary>
    public partial class CallCardView : Window {
        CallCardForm callCardForm;
        List<LibCallCard> callCardList;
        LibCallCard selectedCallCard;

        public CallCardView() {
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

        ~CallCardView() {
            callCardForm.OnCallCardFormSaved -= CallCardForm_OnCallCardFormSaved;
        }

        private void CallCardForm_OnCallCardFormSaved(LibCallCard callCard) {
            selectedCallCard.CopyFrom(callCard);
            CallCardDataGrid.ItemsSource = null;
            CallCardDataGrid.ItemsSource = callCardList;
        }

        private void CallCardNewBtn_Click(object sender, RoutedEventArgs e) {
        }

        private void CallCardUpdateBtn_Click(object sender, RoutedEventArgs e) {
            selectedCallCard = CallCardDataGrid.SelectedItem as LibCallCard;

            callCardForm.Title = "Update Form";
            callCardForm.CallCardFormTitleTxt.Text = "UPDATE THE CALL CARD";
            callCardForm.CallCardIdTxt.IsEnabled = false;
            callCardForm.CallCardIdTxt.Text = selectedCallCard.CallCardId;
            callCardForm.DueDateTxt.Text = selectedCallCard.DueDate.ToString();
            callCardForm.BookIdTxt.IsEnabled = false;
            callCardForm.BookIdTxt.Text = selectedCallCard.BookId.ToString();
            callCardForm.MembershipIdTxt.Text = selectedCallCard.MembershipId;
            callCardForm.StatusTxt.IsEnabled = false;
            callCardForm.StatusTxt.Text = selectedCallCard.Status.ToString();
            callCardForm.CreatorIdTxt.Text = selectedCallCard.CreatorId;
            callCardForm.CreatedDateTxt.IsEnabled = false;
            callCardForm.CreatedDateTxt.Text = selectedCallCard.CreatedDate.ToString();

            callCardForm.ShowDialog();
        }

        private void CallCardRemoveBtn_Click(object sender, RoutedEventArgs e) {
            selectedCallCard = CallCardDataGrid.SelectedItem as LibCallCard;
            if (MessageBox.Show("Are you sure you want to remove the following callCard?\n\n- Call Card ID: " + selectedCallCard.CallCardId, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) {
                callCardList.Remove(selectedCallCard);
                CallCardDataGrid.ItemsSource = null;
                CallCardDataGrid.ItemsSource = callCardList;
                //Update database
            }
        }
    }
}
