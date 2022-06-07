using Client.Models;
using System;
using System.Windows;

namespace Client.Views.Main.Features.Dialogs
{
    /// <summary>
    /// Interaction logic for CallCardForm.xaml
    /// </summary>
    public partial class CallCardForm : Window
    {
        public Action<LibCallCard> OnCallCardFormSaved;

        public CallCardForm()
        {
            InitializeComponent();
        }

        private void CallCardFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            LibCallCard callCard = new LibCallCard();

            callCard.DueDate = DateTime.Parse(DueDateTxt.Text);
            callCard.MembershipId = MembershipIdTxt.Text;
            callCard.CreatorId = CreatorIdTxt.Text;
            //Update database
            OnCallCardFormSaved?.Invoke(callCard);

            Hide();
        }

        private void CallCardFormCancelBtn_Click(object sender, RoutedEventArgs e)
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
