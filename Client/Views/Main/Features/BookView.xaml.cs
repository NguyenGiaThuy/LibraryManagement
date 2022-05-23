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
            bookList.Add(new Book("1285740629", "ACalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 21));
            bookList.Add(new Book("1617295485", "AAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 13));
            bookList.Add(new Book("006230125X", "AElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), new DateTime(2019, 11, 18), "353856",10, 5));
            bookList.Add(new Book("1285740629", "BCalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 21));
            bookList.Add(new Book("1617295485", "BAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 13));
            bookList.Add(new Book("006230125X", "BElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), new DateTime(2019, 11, 18), "353856", 10, 5));
            bookList.Add(new Book("1285740629", "CCalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 21));
            bookList.Add(new Book("1617295485", "CAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 13));
            bookList.Add(new Book("006230125X", "CElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), new DateTime(2019, 11, 18), "353856", 10, 5));
            bookList.Add(new Book("1285740629", "DCalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 21));
            bookList.Add(new Book("1617295485", "DAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 13));
            bookList.Add(new Book("006230125X", "DElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), new DateTime(2019, 11, 18), "353856", 10, 5));
            bookList.Add(new Book("1285740629", "ECalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 21));
            bookList.Add(new Book("1617295485", "EAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 13));
            bookList.Add(new Book("006230125X", "EElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), new DateTime(2019, 11, 18), "353856", 10, 5));
            bookList.Add(new Book("1285740629", "FCalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 21));
            bookList.Add(new Book("1617295485", "FAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 13));
            bookList.Add(new Book("006230125X", "FElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), new DateTime(2019, 11, 18), "353856", 10, 5));
            bookList.Add(new Book("1285740629", "GCalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 21));
            bookList.Add(new Book("1617295485", "GAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 13));
            bookList.Add(new Book("006230125X", "GElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), new DateTime(2019, 11, 18), "353856", 10, 5));
            BookDataGrid.ItemsSource = bookList;
        }

        private void BookNewBtn_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Add a book");
        }

        private void BookUpdateBtn_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Update the book");
        }

        private void BookRemoveBtn_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Remove the book");
        }

        private void AuthorTxt_TextChanged(object sender, TextChangedEventArgs e) {
            AuthorTxt.ScrollToEnd();
        }

        private void PublisherTxt_TextChanged(object sender, TextChangedEventArgs e) {
            PublisherTxt.ScrollToEnd();
        }
    }
}
