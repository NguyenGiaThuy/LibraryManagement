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
using System.Globalization;
using Client;
using Client.Models;
using Client.Views.Main.Features.Dialogs;

namespace Client.Views.Main.Features {
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>

    public partial class BookView : Window {
        BookForm bookForm;
        List<LibBook> bookList;
        LibBook selectedBook;

        public BookView() {
            InitializeComponent();

            BookDataGrid.Focus();
            //Get books from database
            bookList = new List<LibBook>();
            bookList.Add(new LibBook("1285740629", "ACalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), 25, "803920", "Calculus.jpg"));
            bookList.Add(new LibBook("1617295485", "AAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), 30, "803850", "Algorithms.jpg"));
            bookList.Add(new LibBook("006230125X", "AElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), 13, "809327", "ElonMusk.jpg"));
            BookDataGrid.ItemsSource = bookList;

            bookForm = new BookForm();
            bookForm.OnBookFormSaved += BookForm_OnBookFormSaved;
        }

        ~BookView() {
            bookForm.OnBookFormSaved -= BookForm_OnBookFormSaved;
        }

        private void BookForm_OnBookFormSaved(LibBook book) {
            selectedBook.CopyFrom(book);
            UpdateBookSidePanel(selectedBook);
            BookDataGrid.ItemsSource = null;
            BookDataGrid.ItemsSource = bookList;
        }

        private void ClearBookSidePanel() {
            BookTitleTxt.Text = "";
            BookIdTxt.Text = "";
            AuthorTxt.Text = "";
            PublisherTxt.Text = "";
            ISBNTxt.Text = "";
            GenreTxt.Text = "";
            BookImg.Source = null;
        }

        private void UpdateBookSidePanel(LibBook book) {
            BookTitleTxt.Text = book.Title;
            BookIdTxt.Text = book.BookId;
            AuthorTxt.Text = book.Author;
            PublisherTxt.Text = book.Publisher;
            ISBNTxt.Text = book.Isbn;
            GenreTxt.Text = book.Genre.ToString();
            BookImg.Source = new BitmapImage(new Uri("pack://application:,,,/Client;component/Assets/Images/Books/" + book.ImageUrl));
        }

        private void BookNewBtn_Click(object sender, RoutedEventArgs e) {
               
        }

        private void BookUpdateBtn_Click(object sender, RoutedEventArgs e) {
            selectedBook = BookDataGrid.SelectedItem as LibBook;

            bookForm.Title = "Update Form";
            bookForm.BookFormTitleTxt.Text = "UPDATE THE BOOK";
            bookForm.TitleTxt.Text = selectedBook.Title;
            bookForm.ISBNTxt.IsEnabled = false;
            bookForm.ISBNTxt.Text = selectedBook.Isbn;
            bookForm.GenreTxt.Text = selectedBook.Genre.ToString();
            bookForm.BookIdTxt.IsEnabled = false;
            bookForm.BookIdTxt.Text = selectedBook.BookId;
            bookForm.AuthorTxt.Text = selectedBook.Author;
            bookForm.PublisherTxt.Text = selectedBook.Publisher;
            bookForm.PublishedDateTxt.Text = selectedBook.PublishedDate.ToString();
            bookForm.ReceiverIdTxt.IsEnabled = false;
            bookForm.ReceiverIdTxt.Text = selectedBook.ReceiverId;
            bookForm.ReceivedDateTxt.IsEnabled = false;
            bookForm.ReceivedDateTxt.Text = selectedBook.ReceivedDate.ToString();
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
            selectedBook = BookDataGrid.SelectedItem as LibBook;
            if (MessageBox.Show("Are you sure you want to remove the following book?\n\n- Title: " + selectedBook.Title + "\n- Author: " + selectedBook.Author + "\n- ISBN: " + selectedBook.Isbn + "\n- Publisher: " + selectedBook.Publisher, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) {
                bookList.Remove(selectedBook);
                BookDataGrid.ItemsSource = null;
                BookDataGrid.ItemsSource = bookList;
                //Update database
                ClearBookSidePanel();
            }
        }

        private void BookDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectedBook = BookDataGrid.SelectedItem as LibBook;
            if (selectedBook != null) {
                UpdateBookSidePanel(selectedBook);
            }
        }
    }
}
