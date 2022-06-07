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
            fineCard.Reason = int.Parse(ReasonTxt.Text);
            fineCard.Status = int.Parse(StatusTxt.Text);
            fineCard.CreatorId = CreatorIdTxt.Text;
            fineCard.CreatedDate = DateTime.Parse(CreatedDateTxt.Text);
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
    }
}
