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
using Microsoft.Win32;
using System.Diagnostics;
using System.Globalization;
using Client;
using Client.Models;
using Client.Views.Main.Features.Dialogs;

namespace Client.Views.Main.Features {
    /// <summary>
    /// Interaction logic for BookManagementCardView.xaml
    /// </summary>
    public partial class BookAuditCardView : Window {
        List<LibBookAuditCard> bookAuditCardList;
        LibBookAuditCard selectedBookAuditCard;

        public BookAuditCardView() {
            InitializeComponent();

            BookAuditCardDataGrid.Focus();
            //Get bookAuditCards from database
            bookAuditCardList = new List<LibBookAuditCard>();
            bookAuditCardList.Add(new LibBookAuditCard("902920", 0, 0, "029303"));
            bookAuditCardList.Add(new LibBookAuditCard("904859", 0, 0, "024567"));
            bookAuditCardList.Add(new LibBookAuditCard("924567", 0, 0, "029456"));
            BookAuditCardDataGrid.ItemsSource = bookAuditCardList;
        }

        private void BookAuditCardNewBtn_Click(object sender, RoutedEventArgs e) {
        }
    }
}
