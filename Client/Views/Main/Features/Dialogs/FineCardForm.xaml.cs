using Client.Models;
using System;
using System.Windows;

namespace Client.Views.Main.Features.Dialogs
{
    /// <summary>
    /// Interaction logic for FineCardForm.xaml
    /// </summary>
    public partial class FineCardForm : Window
    {
        public Action<LibFineCard> OnFineCardFormSaved;

        public FineCardForm()
        {
            InitializeComponent();
        }

        private void FineCardFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            LibFineCard fineCard = new LibFineCard();

            fineCard.FineCardId = FineCardIdTxt.Text;
            fineCard.Arrears = int.Parse(ArrearsTxt.Text);
            fineCard.DaysInArrears = int.Parse(DaysInArrearsTxt.Text);
            fineCard.CallCardId = CallCardIdTxt.Text;
            fineCard.Reason = ReasonComboBox.SelectedIndex;
            fineCard.Status = StatusComboBox.SelectedIndex;
            fineCard.CreatorId = CreatorIdTxt.Text;
            fineCard.CreatedDate = DateTime.Parse(CreatedDateComboBox.Text);
            //Update database
            OnFineCardFormSaved?.Invoke(fineCard);

            Hide();
        }

        private void FineCardFormCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void CreatedDateComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CreatedDateComboBox.SelectedItem != null)
            {
                DateTime selectedDate = (DateTime)CreatedDateCalendar.SelectedDate;
                CreatedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void CreatedDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)CreatedDateCalendar.SelectedDate;
            CreatedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }
    }
}
