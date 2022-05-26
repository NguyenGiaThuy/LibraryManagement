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
using Client.Views.Main.Features;

namespace Client.Views.Main.Features.Dialogs {
    /// <summary>
    /// Interaction logic for BookForm.xaml
    /// </summary>
    public partial class BookForm : Window {
        public Action<Book> OnBookFormSaved;

        public BookForm() {
            InitializeComponent();
        }

        private void BookFormSaveBtn_Click(object sender, RoutedEventArgs e) {
            Book book = new Book();
            book.Title = TitleTxt.Text;
            book.ISBN = ISBNTxt.Text;
            book.Genre = int.Parse(GenreTxt.Text);
            book.Author = AuthorTxt.Text;
            book.Publisher = PublisherTxt.Text;
            book.PublishedDate = DateTime.Parse(PublishedDateTxt.Text);
            book.Price = int.Parse(PriceTxt.Text);
            //Update database
            OnBookFormSaved?.Invoke(book);
            
            Hide();
        }

        private void BookFormCancelBtn_Click(object sender, RoutedEventArgs e) {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = true;
            Hide();
        }
    }
}
