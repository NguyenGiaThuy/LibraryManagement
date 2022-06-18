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
    /// Interaction logic for FineCardUpdateForm.xaml
    /// </summary>
    public partial class FineCardDetailsForm : Window
    {
        public FineCardDetailsForm()
        {
            InitializeComponent();
        }

        //private void FineCardUpdateFormCancelBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Hide();
        //}

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        //private void CreatedDateComboBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (CreatedDateComboBox.SelectedItem != null)
        //    {
        //        DateTime selectedDate = (DateTime)CreatedDateCalendar.SelectedDate;
        //        CreatedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        //    }
        //}

        //private void CreatedDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //    DateTime selectedDate = (DateTime)CreatedDateCalendar.SelectedDate;
        //    CreatedDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        //}

        private void FineCardDetailsFormCloseBtn_Click(object sender, RoutedEventArgs e) {
            Hide();
        }
    }
}
