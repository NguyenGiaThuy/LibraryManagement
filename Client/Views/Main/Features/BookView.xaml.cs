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
using Microsoft.Win32;
using System.Diagnostics;
using Client;
using Client.Views.Main.Features.Dialogs;
using System.Globalization;

namespace Client.Views.Main.Features {
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>

    public partial class BookView : Window {
        BookForm bookForm;
        List<Book> bookList;
        Book selectedBook;

        public BookView() {
            InitializeComponent();
            BookDataGrid.Focus();
            //Get books from database
            bookList = new List<Book>();
            bookList.Add(new Book("AHG345", "1285740629", "ACalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), "330216", new DateTime(2017, 09, 20), "803920", new DateTime(2021, 03, 18), 29, 1, "Calculus.jpg"));
            bookList.Add(new Book("BD3457", "1617295485", "AAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), "330356", new DateTime(2021, 03, 2), "390293", new DateTime(2021, 11, 09), 47, 1, "Algorithms.jpg"));
            bookList.Add(new Book("SU3926", "006230125X", "AElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), "353856", new DateTime(2019, 11, 18), "203990", new DateTime(2019, 09, 22), 10, 0, "ElonMusk.jpg"));
            BookDataGrid.ItemsSource = bookList;

            bookForm = new BookForm();
            bookForm.OnBookFormSaved += BookForm_OnBookFormSaved;
        }

        ~BookView() {
            bookForm.OnBookFormSaved -= BookForm_OnBookFormSaved;
        }

        private void BookForm_OnBookFormSaved(Book book) {
            selectedBook.CopyFrom(book);
            UpdateBookSidePanel(selectedBook);
            BookDataGrid.ItemsSource = null;
            BookDataGrid.ItemsSource = bookList;
        }

        private void ClearBookSidePanel() {
            BookTitleTxt.Text = "";
            AuthorTxt.Text = "";
            PublisherTxt.Text = "";
            ISBNTxt.Text = "";
            GenreTxt.Text = "";
            BookImg.Source = null;
        }

        private void UpdateBookSidePanel(Book book) {
            BookTitleTxt.Text = book.Title;
            AuthorTxt.Text = book.Author;
            PublisherTxt.Text = book.Publisher;
            ISBNTxt.Text = book.ISBN;
            GenreTxt.Text = book.Genre.ToString();
            BookImg.Source = new BitmapImage(new Uri("pack://application:,,,/Client;component/Assets/Images/" + book.ImgSource));
        }

        private void BookNewBtn_Click(object sender, RoutedEventArgs e) {
            //bookForm.Title = "Adding Form";
            //bookForm.Height = 580;
            //bookForm.BookFormTitleTxt.Text = "ADD A NEW BOOK";
            //bookForm.TitleTxt.Text = "";
            //bookForm.ISBNTxt.Text = "";
            //bookForm.GenreTxt.Text = "";
            //bookForm.AuthorTxt.Text = "";
            //bookForm.PublisherTxt.Text = "";
            //bookForm.PublishedDateTxt.Text = "";
            //bookForm.ReceiverIdTxt.IsEnabled = true;
            //bookForm.ReceiverIdTxt.Text = "";
            //bookForm.ReceivedDateTxt.IsEnabled = true;
            //bookForm.ReceivedDateTxt.Text = "";
            //bookForm.ModifierIdTxt.IsEnabled = true;
            //bookForm.ModifierIdTxt.Text = "";
            //bookForm.ModifiedDateTxt.IsEnabled = true;
            //bookForm.ModifiedDateTxt.Text = "";
            //bookForm.PriceTxt.Text = "";
            //bookForm.StatusTxt.IsEnabled = true;
            //bookForm.StatusTxt.Text = "";

            //bookForm.ShowDialog();
            //if (bookForm.IsVisible == false) {
            //    BookDataGrid.ItemsSource = null;
            //    BookDataGrid.ItemsSource = bookList;
            //    UpdateBookSidePanel(bookForm.CurrentBook);
            //}
        }

        private void BookUpdateBtn_Click(object sender, RoutedEventArgs e) {
            selectedBook = BookDataGrid.SelectedItem as Book;

            bookForm.Title = "Update Form";
            bookForm.Height = 580;
            bookForm.BookFormTitleTxt.Text = "UPDATE THE BOOK";
            bookForm.TitleTxt.Text = selectedBook.Title;
            bookForm.ISBNTxt.Text = selectedBook.ISBN;
            bookForm.GenreTxt.Text = selectedBook.Genre.ToString();
            bookForm.AuthorTxt.Text = selectedBook.Author;
            bookForm.PublisherTxt.Text = selectedBook.Publisher;
            bookForm.PublishedDateTxt.Text = selectedBook.PublishedDate.ToString();
            bookForm.ReceiverIdTxt.IsEnabled = false;
            bookForm.ReceiverIdTxt.Text = selectedBook.ReceiverId;
            bookForm.ReceivedDateTxt.IsEnabled = false;
            bookForm.ReceivedDateTxt.Text = selectedBook.ReceivedDate.ToString("d", new CultureInfo("pt-BR"));
            bookForm.ModifierIdTxt.IsEnabled = false;
            bookForm.ModifierIdTxt.Text = selectedBook.ModifierId;
            bookForm.ModifiedDateTxt.IsEnabled = false;
            bookForm.ModifiedDateTxt.Text = selectedBook.ModifiedDate.ToString();
            bookForm.PriceTxt.Text = selectedBook.Price.ToString();
            bookForm.StatusTxt.IsEnabled = false;
            bookForm.StatusTxt.Text = selectedBook.Status.ToString();

            bookForm.ShowDialog();
        }

        private void BookRemoveBtn_Click(object sender, RoutedEventArgs e) {
            selectedBook = BookDataGrid.SelectedItem as Book;
            if (MessageBox.Show("Are you sure you want to remove the following book?\n\n- Title: " + selectedBook.Title + "\n- Author: " + selectedBook.Author + "\n- ISBN: " + selectedBook.ISBN + "\n- Publisher: " + selectedBook.Publisher, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) {
                bookList.Remove(selectedBook);
                BookDataGrid.ItemsSource = null;
                BookDataGrid.ItemsSource = bookList;
                //Update database
                ClearBookSidePanel();
            }
        }

        private void BookDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectedBook = BookDataGrid.SelectedItem as Book;
            if (selectedBook != null) {
                UpdateBookSidePanel(selectedBook);
            }
        }
    }
}
