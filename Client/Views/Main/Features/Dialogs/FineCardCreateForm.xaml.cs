using Client.Models;
using System;
using System.Windows;

namespace Client.Views.Main.Features.Dialogs
{
    /// <summary>
    /// Interaction logic for FineCardCreateForm.xaml
    /// </summary>
    public partial class FineCardCreateForm : Window
    {
        public Action<LibFineCard> OnFineCardCreateFormSaved;

        public FineCardCreateForm()
        {
            InitializeComponent();
        }

        private void FineCardCreateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            LibFineCard fineCard = new LibFineCard();

            fineCard.CallCardId = CallCardIdTxt.Text;
            fineCard.Reason = ReasonComboBox.SelectedIndex;
            fineCard.CreatorId = CreatorIdTxt.Text;
            //Update database
            OnFineCardCreateFormSaved?.Invoke(fineCard);

            Hide();
        }

        private void FineCardCreateFormCancelBtn_Click(object sender, RoutedEventArgs e)
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
