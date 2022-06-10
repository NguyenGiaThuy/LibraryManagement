using Client.Models;
using Client.Views.Main.Features.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Client.Views.Main.Features
{
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>

    public partial class BookView : Window
    {
        BookForm bookForm;
        List<LibBook> bookList;
        LibBook selectedBook;

        public BookView()
        {
            InitializeComponent();

            BookDataGrid.Focus();
            //Get books from database
            bookList = new List<LibBook>();
            bookList.Add(new LibBook("1285740629", "ACalculus", 2, "James Stewart", "Cengage Learning", new DateTime(2015, 05, 19), 25, "803920", "https://www.ubuy.vn/productimg/?image=aHR0cHM6Ly9pbWFnZXMtbmEuc3NsLWltYWdlcy1hbWF6b24uY29tL2ltYWdlcy9JLzUxSHFxTTVXM3JMLmpwZw.jpg"));
            bookList.Add(new LibBook("1617295485", "AAdvanced Algorithms and Data Structures", 1, "Marcello La Rocca", "Manning", new DateTime(2021, 07, 29), 30, "803850", "https://images.manning.com/book/e/59c8b18-b8fd-4d32-939b-25dcbb4d525d/Rocca-ADS-HI.png"));
            bookList.Add(new LibBook("006230125X", "AElon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", 0, "Ashlee Vance", "Ecco", new DateTime(2017, 01, 24), 13, "809327", "https://images-na.ssl-images-amazon.com/images/I/5112YFsXIJL.jpg"));
            BookDataGrid.ItemsSource = bookList;

            bookForm = new BookForm();
            bookForm.OnBookFormSaved += BookForm_OnBookFormSaved;
        }

        ~BookView()
        {
            bookForm.OnBookFormSaved -= BookForm_OnBookFormSaved;
        }

        private void BookForm_OnBookFormSaved(LibBook book)
        {
            selectedBook.CopyFrom(book);
            UpdateBookSidePanel(selectedBook);
            BookDataGrid.ItemsSource = null;
            BookDataGrid.ItemsSource = bookList;
        }

        private void ClearBookSidePanel()
        {
            BookTitleTxt.Text = "";
            AuthorTxt.Text = "";
            PublisherTxt.Text = "";
            ISBNTxt.Text = "";
            GenreTxt.Text = "";
            PriceTxt.Text = "";
            BookImg.Source = null;
        }

        private void UpdateBookSidePanel(LibBook book)
        {
            BookTitleTxt.Text = book.Title;
            AuthorTxt.Text = book.Author;
            PublisherTxt.Text = book.Publisher;
            ISBNTxt.Text = book.Isbn;
            GenreTxt.Text = book.Genre.ToString();
            PriceTxt.Text = book.Price.ToString();
            BookImg.Source = new BitmapImage(new Uri(book.ImageUrl));
        }

        private void BookNewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BookUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedBook = BookDataGrid.SelectedItem as LibBook;
            //bookForm description
            bookForm.Title = "Update Form";
            bookForm.BookFormTitleTxt.Text = "CẬP NHẬT SÁCH";
            //Title
            bookForm.TitleTxt.Text = selectedBook.Title;
            //ISBN
            bookForm.ISBNTxt.IsEnabled = false;
            bookForm.ISBNTxt.Text = selectedBook.Isbn;
            //Genre
            bookForm.GenreComboBox.Text = selectedBook.Genre.ToString();
            //BookId
            bookForm.BookIdTxt.IsEnabled = false;
            bookForm.BookIdTxt.Text = selectedBook.BookId;
            //Author
            bookForm.AuthorTxt.Text = selectedBook.Author;
            //Publisher
            bookForm.PublisherTxt.Text = selectedBook.Publisher;
            //PublishedDate
            DateTime publishedDate = (DateTime)selectedBook.PublishedDate;
            bookForm.PublishedDateComboBox.Text = publishedDate.ToString("dd-MM-yyyy");
            //ReceiverId
            bookForm.ReceiverIdTxt.IsEnabled = false;
            bookForm.ReceiverIdTxt.Text = selectedBook.ReceiverId;
            //ReceivedDate
            bookForm.ReceivedDateComboBox.IsEnabled = false;
            DateTime receivedDate;
            if (DateTime.TryParse(selectedBook.ReceivedDate.ToString(), out receivedDate)) {
                bookForm.ReceivedDateComboBox.Text = receivedDate.ToString("dd-MM-yyyy");
            }
            else {
                bookForm.ReceivedDateComboBox.Text = "";
            }
            //ModifierId
            bookForm.ModifierIdTxt.IsEnabled = false;
            bookForm.ModifierIdTxt.Text = selectedBook.ModifierId;
            //ModifiedDate
            bookForm.ModifiedDateComboBox.IsEnabled = false;
            DateTime modifiedDate;
            if(DateTime.TryParse(selectedBook.ModifiedDate.ToString(), out modifiedDate)) {
                bookForm.ModifiedDateComboBox.Text = modifiedDate.ToString("dd-MM-yyyy");
            } else {
                bookForm.ModifiedDateComboBox.Text = "";
            }
            //Price
            bookForm.PriceTxt.Text = selectedBook.Price.ToString();
            //Status
            bookForm.StatusComboBox.IsEnabled = false;
            bookForm.StatusComboBox.Text = selectedBook.Status.ToString();

            bookForm.ShowDialog();
        }

        private void BookRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedBook = BookDataGrid.SelectedItem as LibBook;
            if (MessageBox.Show("Are you sure you want to remove the following book?\n\n- Title: " + selectedBook.Title + "\n- Author: " + selectedBook.Author + "\n- ISBN: " + selectedBook.Isbn + "\n- Publisher: " + selectedBook.Publisher, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                bookList.Remove(selectedBook);
                BookDataGrid.ItemsSource = null;
                BookDataGrid.ItemsSource = bookList;
                //Update database
                ClearBookSidePanel();
            }
        }

        private void BookDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBook = BookDataGrid.SelectedItem as LibBook;
            if (selectedBook != null)
            {
                UpdateBookSidePanel(selectedBook);
            }
        }
    }
}
