using Client.Models;
using System;
using System.Windows;

namespace Client.Views.Main.Features.Dialogs
{
    /// <summary>
    /// Interaction logic for BookCreateForm.xaml
    /// </summary>
    public partial class BookCreateForm : Window
    {
        public Action<LibBook> OnBookCreateFormSaved;

        public BookCreateForm()
        {
            InitializeComponent();
        }

        private void BookCreateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            LibBook book = new LibBook();

            book.Isbn = ISBNTxt.Text;
            book.Title = TitleTxt.Text;
            book.Genre = GenreComboBox.SelectedIndex;
            book.Author = AuthorTxt.Text;
            book.Publisher = PublisherTxt.Text;
            book.PublishedDate = DateTime.Parse(PublishedDateComboBox.Text);
            book.Price = int.Parse(PriceTxt.Text);
            //Update database
            OnBookCreateFormSaved?.Invoke(book);

            Hide();
        }

        private void BookCreateFormCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void PublishedDateComboBox_LostFocus(object sender, RoutedEventArgs e) {
            if (PublishedDateComboBox.SelectedItem != null) {
                DateTime selectedDate = (DateTime)PublishedDateCalendar.SelectedDate;
                PublishedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void PublishedDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            DateTime selectedDate = (DateTime)PublishedDateCalendar.SelectedDate;
            PublishedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }
    }
}
