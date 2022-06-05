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
using Client.Views.Main.Features;
using Client.Models;

namespace Client.Views.Main.Features.Dialogs {
    /// <summary>
    /// Interaction logic for FineCardForm.xaml
    /// </summary>
    public partial class FineCardForm : Window {
        public Action<LibFineCard> OnFineCardFormSaved;

        public FineCardForm() {
            InitializeComponent();
        }

        private void FineCardFormSaveBtn_Click(object sender, RoutedEventArgs e) {
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

        private void FineCardFormCancelBtn_Click(object sender, RoutedEventArgs e) {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = true;
            Hide();
        }
    }
}
