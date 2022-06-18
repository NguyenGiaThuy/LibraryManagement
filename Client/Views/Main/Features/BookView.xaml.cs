using Client.Models;
using Client.Views.Main.Features.Dialogs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Client.Views.Main.Features
{
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>

    public partial class BookView : Window {
        BookCreateForm bookCreateForm;
        BookUpdateForm bookUpdateForm;
        List<LibBook> bookList;
        LibBook selectedBook;

        public static async Task<BookView> Create() {
            var bookView = new BookView();
            bookView.bookList = await bookView.GetBooksAsync($"api/libbooks");
            bookView.BookDataGrid.ItemsSource = bookView.bookList;
            return bookView;
        }

        public BookView() {
            InitializeComponent();

            BookDataGrid.Focus();
            bookUpdateForm = new BookUpdateForm();
            bookCreateForm = new BookCreateForm();
            bookCreateForm.OnBookFormSaved += BookCreateForm_OnFormSaved;
            bookUpdateForm.OnBookFormSaved += BookUpdateForm_OnFormSaved;
        }

        ~BookView() {
            bookCreateForm.OnBookFormSaved -= BookCreateForm_OnFormSaved;
            bookUpdateForm.OnBookFormSaved -= BookUpdateForm_OnFormSaved;
        }

        private async Task<List<LibBook>> GetBooksAsync(string path) {
            List<LibBook> books = null;
            var response = await App.Client.GetAsync(path);
            if (response.IsSuccessStatusCode) books = await response.Content.ReadAsAsync<List<LibBook>>();
            return books;
        }

        private async Task<LibBook> DisableBookAsync(string path) {
            LibBook book = new LibBook();
            var response = await App.Client.PutAsJsonAsync(path, book);
            response.EnsureSuccessStatusCode();
            book = await response.Content.ReadAsAsync<LibBook>();
            return book;
        }

        private void BookCreateForm_OnFormSaved(LibBook book) {
            bookList.Add(book);
            BookDataGrid.ItemsSource = null;
            BookDataGrid.ItemsSource = bookList;
        }

        private void BookUpdateForm_OnFormSaved(LibBook book) {
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
            PriceTxt.Text = "";
            BookImg.Source = null;
        }

        private void UpdateBookSidePanel(LibBook book) {
            BookTitleTxt.Text = book.Title ?? "";
            AuthorTxt.Text = book.Author ?? "";
            PublisherTxt.Text = book.Publisher ?? "";
            ISBNTxt.Text = book.Isbn ?? "";
            GenreTxt.Text = book.Genre != null ? book.Genre.ToString() : "";
            PriceTxt.Text = book.Price.ToString() ?? "";
            try {
                BookImg.Source = book.ImageUrl != null ? new BitmapImage(new Uri(book.ImageUrl)) : null;
            }
            catch (Exception) { }
        }

        private void BookNewBtn_Click(object sender, RoutedEventArgs e) {
            bookCreateForm.TitleTxt.Text = "";
            bookCreateForm.ISBNTxt.Text = "";
            bookCreateForm.GenreComboBox.SelectedIndex = -1;
            bookCreateForm.AuthorTxt.Text = "";
            bookCreateForm.PublisherTxt.Text = "";
            bookCreateForm.PublishedDateComboBox.Text = "";
            bookCreateForm.PriceTxt.Text = "";
            bookCreateForm.ImgTxt.Text = "";

            bookCreateForm.ShowDialog();
        }

        private void BookUpdateBtn_Click(object sender, RoutedEventArgs e) {
            selectedBook = BookDataGrid.SelectedItem as LibBook;

            //BookIdTxt
            bookUpdateForm.BookIdTxt.Text = selectedBook.BookId;
            //TitleTxt
            bookUpdateForm.TitleTxt.Text = selectedBook.Title ?? "";
            //ISBNTxt
            bookUpdateForm.ISBNTxt.Text = selectedBook.Isbn;
            //GenreComboBox
            bookUpdateForm.GenreComboBox.Text = selectedBook.Genre.ToString() ?? "";
            //AuthorTxt
            bookUpdateForm.AuthorTxt.Text = selectedBook.Author ?? "";
            //PublisherTxt
            bookUpdateForm.PublisherTxt.Text = selectedBook.Publisher ?? "";
            //PublishedDateComboBox
            DateTime publishedDate = selectedBook.PublishedDate != null ? (DateTime)selectedBook.PublishedDate : DateTime.MinValue;
            bookUpdateForm.PublishedDateComboBox.Text = selectedBook.PublishedDate != null ? publishedDate.ToString("dd-MM-yyyy") : "";
            //ReceiverIdTxt
            bookUpdateForm.ReceiverIdTxt.Text = selectedBook.ReceiverId;
            //ReceivedDateComboBox
            DateTime receivedDate = selectedBook.ReceivedDate != null ? (DateTime)selectedBook.ReceivedDate : DateTime.MinValue;
            bookUpdateForm.ReceivedDateComboBox.Text = selectedBook.ReceivedDate != null ? receivedDate.ToString("dd-MM-yyyy") : "";
            //ModifierIdTxt
            bookUpdateForm.ModifierIdTxt.Text = selectedBook.ModifierId;
            //ModifiedDateComboBox
            DateTime modifiedDate = selectedBook.ModifiedDate != null ? (DateTime)selectedBook.ModifiedDate : DateTime.MinValue;
            bookUpdateForm.ModifiedDateComboBox.Text = selectedBook.ModifiedDate != null ? modifiedDate.ToString("dd-MM-yyyy") : "";
            //PriceTxt
            bookUpdateForm.PriceTxt.Text = selectedBook.Price.ToString();
            //StatusComboBox
            bookUpdateForm.StatusComboBox.Text = selectedBook.Status.ToString();

            bookUpdateForm.ShowDialog();
        }

        private void BookRemoveBtn_Click(object sender, RoutedEventArgs e) {
            selectedBook = BookDataGrid.SelectedItem as LibBook;
            if (MessageBox.Show("Are you sure you want to remove the following book?\n\n- Title: " + selectedBook.Title + "\n- Author: " + selectedBook.Author + "\n- ISBN: " + selectedBook.Isbn + "\n- Publisher: " + selectedBook.Publisher, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) {
                try {
                    //await DisableUserAsync($"api/libusers/{selectedUser.UserId}/disable");

                    //    userList.Find(x => x.UserId == selectedUser.UserId).Status = LibUser.UserStatus.Inactive;
                    //    UserDataGrid.ItemsSource = null;
                    //    UserDataGrid.ItemsSource = userList;
                    ClearBookSidePanel();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BookDataGrid_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e) {
            selectedBook = BookDataGrid.SelectedItem as LibBook;
            if (selectedBook != null) UpdateBookSidePanel(selectedBook);
        }
    }
}
