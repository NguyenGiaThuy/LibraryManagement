using Client.Models;
using System;
using System.Windows;

namespace Client.Views.Main.Features.Dialogs
{
    /// <summary>
    /// Interaction logic for CallCardCreateForm.xaml
    /// </summary>
    public partial class CallCardCreateForm : Window
    {
        public Action<LibCallCard> OnCallCardCreateFormSaved;

        public CallCardCreateForm()
        {
            InitializeComponent();
        }

        private void CallCardCreateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            LibCallCard callCard = new LibCallCard();

            callCard.DueDate = DateTime.Parse(DueDateComboBox.Text);
            callCard.MembershipId = MembershipIdTxt.Text;
            callCard.CreatorId = CreatorIdTxt.Text;
            //Update database
            OnCallCardCreateFormSaved?.Invoke(callCard);

            Hide();
        }

        private void CallCardCreateFormCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void DueDateComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DueDateComboBox.SelectedItem != null)
            {
                DateTime selectedDate = (DateTime)DueDateCalendar.SelectedDate;
                DueDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void DueDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)DueDateCalendar.SelectedDate;
            DueDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }
    }
}
