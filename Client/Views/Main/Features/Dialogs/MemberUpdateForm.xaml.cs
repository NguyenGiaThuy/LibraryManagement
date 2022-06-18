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
    /// Interaction logic for MemberUpdateForm.xaml
    /// </summary>
    public partial class MemberUpdateForm : Window
    {
        public Action<LibMember> OnMemberFormSaved;

        public MemberUpdateForm()
        {
            InitializeComponent();
        }

        private async Task<LibMember> UpdateMemberAsync(string path, LibMember member) {
            var response = await App.Client.PutAsJsonAsync(path, member);
            response.EnsureSuccessStatusCode();
            member = await response.Content.ReadAsAsync<LibMember>();
            return member;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private async void MemberUpdateFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try {
                LibMember member = new LibMember() {
                    MemberId = MemberIdTxt.Text.Trim(),
                    MembershipId = MembershipIdTxt.Text.Trim(),
                    SocialId = SocialIdTxt.Text.Trim(),
                    Name = NameTxt.Text.Trim(),
                    Dob = DobComboBox.Text.Trim() != "" ? DateTime.ParseExact(DobComboBox.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) : null,
                    Address = AddressTxt.Text.Trim(),
                    Mobile = MobileTxt.Text.Trim(),
                    Email = EmailTxt.Text != "" ?  EmailTxt.Text.Trim() : null,
                    ModifierId = App.User.UserId,
                    ModifiedDate = DateTime.Now,
                    ImageUrl = ImgTxt.Text.Trim()
                };

                OnMemberFormSaved?.Invoke(await UpdateMemberAsync($"api/libmembers/{member.MemberId}", member));

                Hide();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void MemberUpdateFormCancelBtn_Click(object sender, RoutedEventArgs e)
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

        private void CreatedDateComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CreatedDateComboBox.SelectedItem != null)
            {
                DateTime selectedDate = (DateTime)CreatedDateCalendar.SelectedDate;
                CreatedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void CreatedDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)CreatedDateCalendar.SelectedDate;
            CreatedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
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
