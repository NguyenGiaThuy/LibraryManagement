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
            book.Genre = GenreComboBox.SelectedIndex;
            book.Author = AuthorTxt.Text;
            book.Publisher = PublisherTxt.Text;
            book.PublishedDate = DateTime.Parse(PublishedDateComboBox.Text);
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

        private void PublishedDateComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PublishedDateComboBox.SelectedItem != null)
            {
                DateTime selectedDate = (DateTime)PublishedDateCalendar.SelectedDate;
                PublishedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void PublishedDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)PublishedDateCalendar.SelectedDate;
            PublishedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }

        private void ReceivedDateComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ReceivedDateComboBox.SelectedItem != null)
            {
                DateTime selectedDate = (DateTime)ReceivedDateCalendar.SelectedDate;
                ReceivedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void ReceivedDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)ReceivedDateCalendar.SelectedDate;
            ReceivedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }

        private void ModifiedDateComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ModifiedDateComboBox.SelectedItem != null)
            {
                DateTime selectedDate = (DateTime)ModifiedDateCalendar.SelectedDate;
                ModifiedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void ModifiedDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)ModifiedDateCalendar.SelectedDate;
            ModifiedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }
    }
}
