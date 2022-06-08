using System;
using System.Windows;

namespace Client.Views.Main.Features.Dialogs
{
    /// <summary>
    /// Interaction logic for MemberForm.xaml
    /// </summary>
    public partial class MemberForm : Window
    {
        public MemberForm()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void UserFormSaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserFormCancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DobComboBox_LostFocus(object sender, RoutedEventArgs e) {
            if (DobComboBox.SelectedItem != null) {
                DateTime selectedDate = (DateTime)DobCalendar.SelectedDate;
                DobComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void DobCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            DateTime selectedDate = (DateTime)DobCalendar.SelectedDate;
            DobComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }

        private void CreatedDateComboBox_LostFocus(object sender, RoutedEventArgs e) {
            if (CreatedDateComboBox.SelectedItem != null) {
                DateTime selectedDate = (DateTime)CreatedDateCalendar.SelectedDate;
                CreatedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void CreatedDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            DateTime selectedDate = (DateTime)CreatedDateCalendar.SelectedDate;
            CreatedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }

        private void ModifiedDateComboBox_LostFocus(object sender, RoutedEventArgs e) {
            if (ModifiedDateComboBox.SelectedItem != null) {
                DateTime selectedDate = (DateTime)ModifiedDateCalendar.SelectedDate;
                ModifiedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
            }
        }

        private void ModifiedDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            DateTime selectedDate = (DateTime)ModifiedDateCalendar.SelectedDate;
            ModifiedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        }
    }
}
