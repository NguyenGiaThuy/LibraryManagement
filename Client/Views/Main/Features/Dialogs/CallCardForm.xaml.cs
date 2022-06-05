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
    /// Interaction logic for CallCardForm.xaml
    /// </summary>
    public partial class CallCardForm : Window {
        public Action<LibCallCard> OnCallCardFormSaved;

        public CallCardForm() {
            InitializeComponent();
        }

        private void CallCardFormSaveBtn_Click(object sender, RoutedEventArgs e) {
            LibCallCard callCard = new LibCallCard();

            callCard.DueDate = DateTime.Parse(DueDateTxt.Text);
            callCard.MembershipId = MembershipIdTxt.Text;
            callCard.CreatorId = CreatorIdTxt.Text;
            //Update database
            OnCallCardFormSaved?.Invoke(callCard);

            Hide();
        }

        private void CallCardFormCancelBtn_Click(object sender, RoutedEventArgs e) {
            Hide();   
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = true;
            Hide();
        }
    }
}
