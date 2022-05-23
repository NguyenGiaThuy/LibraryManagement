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

        List<Book> bookList = new List<Book>();

        public BookView() {
            InitializeComponent();

            bookList.Add(new Book("1285740629", "ACalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 21, "https://m.media-amazon.com/images/I/41Ln0mEFcdL._AC_SY780_.jpg"));
            bookList.Add(new Book("1617295485", "AAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 13, "https://images-na.ssl-images-amazon.com/images/I/41TgDUtgXmS._SX397_BO1,204,203,200_.jpg"));
            bookList.Add(new Book("006230125X", "AElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), new DateTime(2019, 11, 18), "353856", 10, 5, "https://m.media-amazon.com/images/I/51tw6UjHpDL.jpg"));
            bookList.Add(new Book("1285740629", "BCalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 21, "https://m.media-amazon.com/images/I/41Ln0mEFcdL._AC_SY780_.jpg"));
            bookList.Add(new Book("1617295485", "BAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 13, "https://images-na.ssl-images-amazon.com/images/I/41TgDUtgXmS._SX397_BO1,204,203,200_.jpg"));
            bookList.Add(new Book("006230125X", "BElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), new DateTime(2019, 11, 18), "353856", 10, 5, "https://m.media-amazon.com/images/I/51tw6UjHpDL.jpg"));
            bookList.Add(new Book("1285740629", "CCalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 21, "https://m.media-amazon.com/images/I/41Ln0mEFcdL._AC_SY780_.jpg"));
            bookList.Add(new Book("1617295485", "CAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 13, "https://images-na.ssl-images-amazon.com/images/I/41TgDUtgXmS._SX397_BO1,204,203,200_.jpg"));
            bookList.Add(new Book("006230125X", "CElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), new DateTime(2019, 11, 18), "353856", 10, 5, "https://m.media-amazon.com/images/I/51tw6UjHpDL.jpg"));
            bookList.Add(new Book("1285740629", "DCalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 21, "https://m.media-amazon.com/images/I/41Ln0mEFcdL._AC_SY780_.jpg"));
            bookList.Add(new Book("1617295485", "DAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 13, "https://images-na.ssl-images-amazon.com/images/I/41TgDUtgXmS._SX397_BO1,204,203,200_.jpg"));
            bookList.Add(new Book("006230125X", "DElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), new DateTime(2019, 11, 18), "353856", 10, 5, "https://m.media-amazon.com/images/I/51tw6UjHpDL.jpg"));
            bookList.Add(new Book("1285740629", "ECalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), new DateTime(2017, 09, 20), "330216", 29, 21, "https://m.media-amazon.com/images/I/41Ln0mEFcdL._AC_SY780_.jpg"));
            bookList.Add(new Book("1617295485", "EAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), new DateTime(2021, 03, 2), "330356", 47, 13, "https://images-na.ssl-images-amazon.com/images/I/41TgDUtgXmS._SX397_BO1,204,203,200_.jpg"));
            bookList.Add(new Book("006230125X", "EElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), new DateTime(2019, 11, 18), "353856", 10, 5, "https://m.media-amazon.com/images/I/51tw6UjHpDL.jpg"));
            BookDataGrid.ItemsSource = bookList;
        }

        private void BookNewBtn_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Add a book");
        }

        private void BookUpdateBtn_Click(object sender, RoutedEventArgs e) {
            Book selectedBook = BookDataGrid.SelectedItem as Book;
            if (selectedBook != null) {
                MessageBox.Show("Update the book " + selectedBook.Title);
            }
        }

        private void BookRemoveBtn_Click(object sender, RoutedEventArgs e) {
            Book selectedBook = BookDataGrid.SelectedItem as Book;
            if (selectedBook != null) {
                if (MessageBox.Show("Remove the book: " + selectedBook.Title, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) {
                    bookList.Remove(selectedBook);
                    BookDataGrid.ItemsSource = null;
                    BookDataGrid.ItemsSource = bookList;
                }
            }
        }

        private void AuthorTxt_TextChanged(object sender, TextChangedEventArgs e) {
            AuthorTxt.ScrollToEnd();
        }

        private void PublisherTxt_TextChanged(object sender, TextChangedEventArgs e) {
            PublisherTxt.ScrollToEnd();
        }

        private void BookDataGridRow_MouseDown(object sender, MouseButtonEventArgs e) {
            var row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;

            if (row == null) {
                return;
            }
            else {
                Book selectedBook = (Book)row.DataContext;
                BookTitleTxt.Text = selectedBook.Title;
                AuthorTxt.Text = selectedBook.Author;
                PublisherTxt.Text = selectedBook.Publisher;
                LanguageTxt.Text = "English";
                PagesTxt.Text = "";
                ISBNTxt.Text = selectedBook.ISBN;
                GenreTxt.Text = selectedBook.Genre.ToString();
                BookImg.Source = new BitmapImage(new Uri(selectedBook.ImgSource));
            }
        }
    }
}
