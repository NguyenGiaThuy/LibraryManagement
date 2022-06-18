using Client.Models;
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

namespace Client.Views.Main.Features.Dialogs
{
    /// <summary>
    /// Interaction logic for CallCardUpdateForm.xaml
    /// </summary>
    public partial class CallCardUpdateForm : Window
    {
        public Action<LibCallCard> OnCallCardFormSaved;

        public CallCardUpdateForm()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private async Task<LibCallCard> UpdateCallCardStateAsync(string path)
        {
            LibCallCard callcard = new LibCallCard();
            var response = await App.Client.PutAsJsonAsync(path, callcard);
            response.EnsureSuccessStatusCode();
            callcard = await response.Content.ReadAsAsync<LibCallCard>();
            return callcard;
        }

        private async void CallCardUpdateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnCallCardFormSaved?.Invoke(await UpdateCallCardStateAsync($"api/libmembers/{CallCardIdTxt.Text.Trim()}"));

                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CallCardUpdateFormCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
