using Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Client.Views.Main.Features.Dialogs {
    /// <summary>
    /// Interaction logic for BookRemoveForm.xaml
    /// </summary>
    public partial class BookRemoveForm : Window {
        public Action<LibBook> OnBookFormSaved;
        public LibBook SelectedBook { get; set; }

        public BookRemoveForm() {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = true;
            Hide();
        }

        private async Task<LibBook> RemoveBookAsync(string path, LibBook book)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(App.Client.BaseAddress, path),
                Content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json")
            };
            var response = await App.Client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            book = await response.Content.ReadAsAsync<LibBook>();
            return book;
        }

        private async void BookRemoveFormRemoveBtn_Click(object sender, RoutedEventArgs e) {
            try
            {
                string selectedBookId = BookIdTxt.Text.Trim();
                int reason = ReasonComboBox.SelectedIndex;

                SelectedBook.ModifierId = App.User.UserId;
                SelectedBook.ModifiedDate = DateTime.Now;

                LibBook book = await RemoveBookAsync($"api/libbooks/{selectedBookId}/{reason}", SelectedBook);
                OnBookFormSaved?.Invoke(book);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BookRemoveFormCancelBtn_Click(object sender, RoutedEventArgs e) {
            Hide();
        }
    }
}
