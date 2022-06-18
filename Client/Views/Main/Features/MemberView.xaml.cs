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
        LibMember selectedMember;

        public static async Task<MemberView> Create() {
            var memberView = new MemberView();
            memberView.memberList = await memberView.GetMembersAsync($"api/libmembers");
            memberView.MemberDataGrid.ItemsSource = memberView.memberList;
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
            //selectedMember.CopyFrom(member);
            //UpdateMemberSidePanel(selectedMember);
            //MemberDataGrid.ItemsSource = null;
            //MemberDataGrid.ItemsSource = memberList;
        }

        private void MemberNewBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MemberUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MemberRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MemberDataGrid_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {

        }

        private void MemberEnableBtn_Click(object sender, RoutedEventArgs e) {

        }
    }
}
