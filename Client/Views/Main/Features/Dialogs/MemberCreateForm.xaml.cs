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
    /// Interaction logic for MemberCreateForm.xaml
    /// </summary>
    public partial class MemberCreateForm : Window
    {
        public Action<LibMember> OnMemberFormSaved;

        private async Task<LibMember> CreateMemberAsync(string path, LibMember member) {
            var response = await App.Client.PostAsJsonAsync(path, member);
            response.EnsureSuccessStatusCode();
            member = await response.Content.ReadAsAsync<LibMember>();
            return member;
        }

        public MemberCreateForm()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private async void MemberCreateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try {
                LibMember member = new LibMember(SocialIdTxt.Text.Trim(),
                    NameTxt.Text.Trim(),
                    DobComboBox.Text.Trim() != "" ? DateTime.ParseExact(DobComboBox.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) : null,
                    AddressTxt.Text.Trim(),
                    MobileTxt.Text.Trim(),
                    EmailTxt.Text.Trim(),
                    App.User.UserId,
                    ImgTxt.Text.Trim()) { }; 

                OnMemberFormSaved?.Invoke(await CreateMemberAsync($"api/libmembers", member));

                Hide();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void MemberCreateFormCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void DobComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DobComboBox.SelectedItem != null)
            {
                DateTime selectedDate = (DateTime)DobCalendar.SelectedDate;
                DobComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void DobCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)DobCalendar.SelectedDate;
            DobComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }
    }
}
