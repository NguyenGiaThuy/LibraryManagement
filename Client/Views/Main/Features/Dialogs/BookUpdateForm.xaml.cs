using Client.Models;
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Views.Main.Features.Dialogs
{
    /// <summary>
    /// Interaction logic for BookUpdateForm.xaml
    /// </summary>
    public partial class BookUpdateForm : Window
    {
        public Action<LibBook> OnBookFormSaved;

        public BookUpdateForm()
        {
            InitializeComponent();
        }

        private async Task<LibBook> UpdateBookAsync(string path, LibBook book) {
            var response = await App.Client.PutAsJsonAsync(path, book);
            response.EnsureSuccessStatusCode();
            book = await response.Content.ReadAsAsync<LibBook>();
            return book;
        }

        private async void BookUpdateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LibBook book = new LibBook() 
                {
                    BookId = BookIdTxt.Text.Trim(),
                    Isbn = ISBNTxt.Text.Trim(),
                    Title = TitleTxt.Text.Trim(),
                    Genre = GenreComboBox.SelectedIndex != -1 ? (LibBook.BookGenre)GenreComboBox.SelectedIndex : null,
                    Author = AuthorTxt.Text.Trim(),
                    Publisher = PublisherTxt.Text.Trim(),
                    PublishedDate = PublishedDateComboBox.Text.Trim() != "" ? DateTime.ParseExact(PublishedDateComboBox.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) : null,
                    Price = PriceTxt.Text.Trim() != "" ? int.Parse(PriceTxt.Text) : null,
                    ImageUrl = ImgTxt.Text.Trim(),
                    ModifierId = App.User.UserId,
                    ModifiedDate = DateTime.Now
                };

                OnBookFormSaved?.Invoke(await UpdateBookAsync($"api/libbooks/{book.BookId}", book));

                Hide();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BookUpdateFormCancelBtn_Click(object sender, RoutedEventArgs e)
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
