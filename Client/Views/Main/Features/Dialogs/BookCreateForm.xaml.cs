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
    /// Interaction logic for BookCreateForm.xaml
    /// </summary>
    public partial class BookCreateForm : Window
    {
        public Action<LibBook> OnBookFormSaved;

        public BookCreateForm()
        {
            InitializeComponent();
        }

        private async Task<LibBook> CreateBookAsync(string path, LibBook book) {
            var response = await App.Client.PostAsJsonAsync(path, book);
            response.EnsureSuccessStatusCode();
            book = await response.Content.ReadAsAsync<LibBook>();
            return book;
        }

        private async void BookCreateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try {
                LibBook book = new LibBook(
                    ISBNTxt.Text.Trim(), 
                    TitleTxt.Text.Trim(), 
                    GenreComboBox.SelectedIndex != -1 ? (LibBook.BookGenre)GenreComboBox.SelectedIndex : null,
                    AuthorTxt.Text.Trim(),
                    PublisherTxt.Text.Trim(),
                    PublishedDateComboBox.Text.Trim() != "" ? DateTime.ParseExact(PublishedDateComboBox.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) : null,
                    PriceTxt.Text.Trim() != "" ? int.Parse(PriceTxt.Text) : null,
                    App.User.UserId,
                    ImgTxt.Text.Trim()) {};

                OnBookFormSaved?.Invoke(await CreateBookAsync($"api/libbooks", book));

                Hide();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
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
    }
}
