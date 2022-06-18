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
    /// Interaction logic for CallCardUpdateForm.xaml
    /// </summary>
    public partial class CallCardDetailsForm : Window
    {
        public CallCardDetailsForm()
        {
            InitializeComponent();
        }

        private void CallCardDetailsFormCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        //private void DueDateComboBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (DueDateComboBox.SelectedItem != null)
        //    {
        //        DateTime selectedDate = (DateTime)DueDateCalendar.SelectedDate;
        //        DueDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        //    }
        //}

        //private void DueDateCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //    DateTime selectedDate = (DateTime)DueDateCalendar.SelectedDate;
        //    DueDateComboBox.Text = selectedDate.ToString("dd-MM-yyyy");
        //}

        //private void CreatedDateTxt_LostFocus(object sender, RoutedEventArgs e)
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
    }
}
