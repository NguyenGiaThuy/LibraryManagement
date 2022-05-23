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
using System.Windows.Controls.Primitives;
using Client.Views.Main.Features.Dialogs;
using Microsoft.Win32;
using System.Diagnostics;
using Client;

namespace Client.Views.Main.Features {
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>

    public partial class BookView : Window {

        public BookView() {
            InitializeComponent();

            List<Book> bookList = new List<Book>();
            bookList.Add(new Book("1285740629", "Calculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 3));
            bookList.Add(new Book("1617295485", "Advanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 5));
            BookDataGrid.ItemsSource = bookList;
        }

        private void BookNewBtn_Click(object sender, RoutedEventArgs e) {
            DecisionView decisionView = new DecisionView();
            decisionView.Title = "Adding new books";
            decisionView.DecisionContentTxt.Text = "What kind of adding do you want?";
            decisionView.IndividualBtn.Content = "Add by form";
            decisionView.MassBtn.Content = "Add from a file";
            decisionView.ShowDialog();
        }

        private void BookUpdateBtn_Click(object sender, RoutedEventArgs e) {
            DecisionView decisionView = new DecisionView();
            decisionView.Title = "Updating books";
            decisionView.DecisionContentTxt.Text = "What kind of updating do you want?";
            decisionView.IndividualBtn.Content = "Individual update";
            decisionView.MassBtn.Content = "Mass update";
            decisionView.ShowDialog();
        }

        private void BookRemoveBtn_Click(object sender, RoutedEventArgs e) {
            DecisionView decisionView = new DecisionView();
            decisionView.Title = "Removing books";
            decisionView.DecisionContentTxt.Text = "What kind of removing do you want?";
            decisionView.IndividualBtn.Content = "Individual remove";
            decisionView.MassBtn.Content = "Mass remove";
            decisionView.ShowDialog();
        }

        private void BookReportBtn_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export a report";
            saveFileDialog.FileName = "Book_Report";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.Filter = "CSV files (.csv)|*.csv";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.ValidateNames = true;
            saveFileDialog.ShowDialog();
        }

        private void AuthorTxt_TextChanged(object sender, TextChangedEventArgs e) {
            AuthorTxt.ScrollToEnd();
        }

        private void PublisherTxt_TextChanged(object sender, TextChangedEventArgs e) {
            PublisherTxt.ScrollToEnd();
        }
    }
}
