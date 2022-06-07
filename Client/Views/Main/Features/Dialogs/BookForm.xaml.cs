using Client.Models;
using System;
using System.Windows;

namespace Client.Views.Main.Features.Dialogs
{
    /// <summary>
    /// Interaction logic for BookForm.xaml
    /// </summary>
    public partial class BookForm : Window
    {
        public Action<LibBook> OnBookFormSaved;

        public BookForm()
        {
            InitializeComponent();
        }

        private void BookFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            LibBook book = new LibBook();

            book.BookId = BookIdTxt.Text;
            book.Isbn = ISBNTxt.Text;
            book.Title = TitleTxt.Text;
            book.Genre = int.Parse(GenreTxt.Text);
            book.Author = AuthorTxt.Text;
            book.Publisher = PublisherTxt.Text;
            book.PublishedDate = DateTime.Parse(PublishedDateTxt.Text);
            book.Price = int.Parse(PriceTxt.Text);
            //Update database
            OnBookFormSaved?.Invoke(book);

            Hide();
        }

        private void BookFormCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
