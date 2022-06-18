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

namespace Client.Views.Main.Features.Dialogs {
    /// <summary>
    /// Interaction logic for BookRemoveForm.xaml
    /// </summary>
    public partial class BookRemoveForm : Window {
        public BookRemoveForm() {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = true;
            Hide();
        }

        private void BookRemoveFormRemoveBtn_Click(object sender, RoutedEventArgs e) {

        }

        private void BookRemoveFormCancelBtn_Click(object sender, RoutedEventArgs e) {
            Hide();
        }
    }
}
