using System;
using System.Collections.Generic;
using System.Linq;
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
using Client;
using Client.Models;

namespace Client.Views.Main.Features.Dialogs {
    /// <summary>
    /// Interaction logic for UserForm.xaml
    /// </summary>
    public partial class UserForm : Window {
        public Action<LibUser> OnUserFormSaved;

        public UserForm() {
            InitializeComponent();
        }
        private void UserFormSaveBtn_Click(object sender, RoutedEventArgs e) {
            LibUser user = new LibUser();

            user.UserId = UserIdTxt.Text;
            user.Password = PasswordTxt.Password;
            user.Name = NameTxt.Text;
            user.Address = AddressTxt.Text;
            user.Dob = DateTime.Parse(DateOfBirthTxt.Text);
            user.Mobile = MobileTxt.Text;
            user.Education = int.Parse(EducationTxt.Text);
            user.Department = int.Parse(DepartmentTxt.Text);
            user.Position = int.Parse(PositionTxt.Text);
            user.Status = int.Parse(StatusTxt.Text);
            //Update database
            OnUserFormSaved?.Invoke(user);

            Hide();
        }

        private void UserFormCancelBtn_Click(object sender, RoutedEventArgs e) {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = true;
            Hide();
        }
    }
}
