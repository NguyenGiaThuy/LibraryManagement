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

namespace Client.Views.Main.Features.Dialogs
{
    /// <summary>
    /// Interaction logic for DecisionView.xaml
    /// </summary>
    public partial class DecisionView : Window
    {
        public DecisionView()
        {
            InitializeComponent();
        }

        private void MassBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt|JSON files (*.json)|*.json";
            openFileDialog.ShowDialog();
        }

        private void IndividualBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\"Under development! This command will pop up a form.\"");
        }
    }
}
