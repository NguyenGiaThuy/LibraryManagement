using Client.Models;
using Client.Views.Main.Features.Dialogs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Client.Views.Main.Features
{
    /// <summary>
    /// Interaction logic for MemberView.xaml
    /// </summary>
    public partial class MemberView : Window
    {
        MemberCreateForm memberCreateForm;
        MemberUpdateForm memberUpdateForm;
        List<LibMember> memberList;
        List<LibMembership> membershipList;
        LibMember selectedMember;
        LibMembership selectedMembership;

        public static async Task<MemberView> Create() {
            var memberView = new MemberView();
            memberView.memberList = await memberView.GetMembersAsync($"api/libmembers");
            memberView.membershipList = await memberView.GetMembershipsAsync($"api/libmemberships");
            memberView.MemberDataGrid.ItemsSource = memberView.membershipList;
            return memberView;
        }

        public MemberView()
        {
            InitializeComponent();

            MemberDataGrid.Focus();
            memberUpdateForm = new MemberUpdateForm();
            memberCreateForm = new MemberCreateForm();
            memberCreateForm.OnMemberFormSaved += MemberCreateForm_OnFormSaved;
            memberUpdateForm.OnMemberFormSaved += MemberUpdateForm_OnFormSaved;
        }

        ~MemberView() {
            memberCreateForm.OnMemberFormSaved -= MemberCreateForm_OnFormSaved;
            memberUpdateForm.OnMemberFormSaved -= MemberUpdateForm_OnFormSaved;
        }

        private async Task<List<LibMember>> GetMembersAsync(string path) {
            List<LibMember> members = null;
            var response = await App.Client.GetAsync(path);
            if (response.IsSuccessStatusCode) members = await response.Content.ReadAsAsync<List<LibMember>>();
            return members;
        }

        private async Task<List<LibMembership>> GetMembershipsAsync(string path)
        {
            List<LibMembership> memberships = null;
            var response = await App.Client.GetAsync(path);
            if (response.IsSuccessStatusCode) memberships = await response.Content.ReadAsAsync<List<LibMembership>>();
            return memberships;
        }

        private async Task<LibMember> DisableMemberAsync(string path) {
            LibMember member = new LibMember();
            var response = await App.Client.PutAsJsonAsync(path, member);
            response.EnsureSuccessStatusCode();
            member = await response.Content.ReadAsAsync<LibMember>();
            return member;
        }

        private void MemberCreateForm_OnFormSaved(LibMember member) {
            memberList.Add(member);
            MemberDataGrid.ItemsSource = null;
            MemberDataGrid.ItemsSource = memberList;
        }

        private void MemberUpdateForm_OnFormSaved(LibMember member) {
            selectedMember.CopyFrom(member);
            UpdateMemberSidePanel(selectedMember);
        }

        private void UpdateMemberSidePanel(LibMember member)
        {
            DateTime dob = member.Dob != null ? (DateTime)member.Dob : DateTime.MinValue;
            DobTxt.Text = member.Dob != null ? dob.ToString("dd-MM-yyyy") : "";

            MemberNameTxt.Text = member.Name ?? "";
            SocialIdTxt.Text = member.SocialId;
            AddressTxt.Text = member.Address ?? "";
            MobileTxt.Text = member.Mobile ?? "";
            EmailTxt.Text = member.Email ?? "";
            try
            {
                MemberImg.Source = member.ImageUrl != null ? new BitmapImage(new Uri(member.ImageUrl)) : null;
            }
            catch (Exception) { }
        }

        private void MemberNewBtn_Click(object sender, RoutedEventArgs e)
        {
            memberCreateForm.SocialIdTxt.Text = "";
            memberCreateForm.DobComboBox.Text = "";
            memberCreateForm.NameTxt.Text = "";
            memberCreateForm.AddressTxt.Text = "";
            memberCreateForm.MobileTxt.Text = "";
            memberCreateForm.EmailTxt.Text = "";
            memberCreateForm.ImgTxt.Text = "";

            memberCreateForm.ShowDialog();
        }

        private void MemberUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedMembership = MemberDataGrid.SelectedItem as LibMembership;
            selectedMember = memberList.Find(x => x.MembershipId == selectedMembership.MembershipId);

            DateTime dob = selectedMember.Dob != null ? (DateTime)selectedMember.Dob : DateTime.MinValue;
            memberUpdateForm.DobComboBox.Text = selectedMember.Dob != null ? dob.ToString("dd-MM-yyyy") : "";

            memberUpdateForm.NameTxt.Text = selectedMember.Name ?? "";
            memberUpdateForm.AddressTxt.Text = selectedMember.Address ?? "";
            memberUpdateForm.MobileTxt.Text = selectedMember.Mobile ?? "";
            memberUpdateForm.EmailTxt.Text = selectedMember.Email ?? "";
            memberUpdateForm.ImgTxt.Text = selectedMember.ImageUrl ?? "";

            memberUpdateForm.ShowDialog();
        }

        private void MemberDataGrid_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            selectedMembership = MemberDataGrid.SelectedItem as LibMembership;
            selectedMember = memberList.Find(x => x.MembershipId == selectedMembership.MembershipId);
            if (selectedMember != null) UpdateMemberSidePanel(selectedMember);
        }

        private async Task<LibMembership> EnableMemberAsync(string path, LibMembership membership)
        {
            var response = await App.Client.PutAsJsonAsync(path, membership);
            response.EnsureSuccessStatusCode();
            membership = await response.Content.ReadAsAsync<LibMembership>();
            return membership;
        }

        private async void MemberEnableBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedMembership.ModifierId = App.User.UserId;
                selectedMembership.ModifiedDate = DateTime.Now;

                await EnableMemberAsync($"api/libmemberships/{selectedMembership.MembershipId}/enable", selectedMembership);

                membershipList.Find(x => x.MembershipId == selectedMembership.MembershipId).Status = LibMembership.MembershipStatus.Active;
                MemberDataGrid.ItemsSource = null;
                MemberDataGrid.ItemsSource = membershipList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task<LibMembership> DisableMemberAsync(string path, LibMembership membership)
        {
            var response = await App.Client.PutAsJsonAsync(path, membership);
            response.EnsureSuccessStatusCode();
            membership = await response.Content.ReadAsAsync<LibMembership>();
            return membership;
        }

        private async void MemberDisableBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove the following user?\n\n- Name: " + selectedMember.Name + "\n- ID: " + selectedMember.SocialId, "Remove", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    selectedMembership.ModifierId = App.User.UserId;
                    selectedMembership.ModifiedDate = DateTime.Now;

                    await DisableMemberAsync($"api/libmemberships/{selectedMembership.MembershipId}/disable", selectedMembership);

                    membershipList.Find(x => x.MembershipId == selectedMembership.MembershipId).Status = LibMembership.MembershipStatus.Inactive;
                    MemberDataGrid.ItemsSource = null;
                    MemberDataGrid.ItemsSource = membershipList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
