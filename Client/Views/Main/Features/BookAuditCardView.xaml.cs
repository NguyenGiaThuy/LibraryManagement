using Client.Models;
using Client.Views.Main.Features.Dialogs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Client.Views.Main.Features
{
    /// <summary>
    /// Interaction logic for BookManagementCardView.xaml
    /// </summary>
    public partial class BookAuditCardView : Window
    {
        List<LibBookAuditCard> bookAuditCardList;
        LibBookAuditCard selectedBookAuditCard;

        public static async Task<BookAuditCardView> Create() {
            var bookAuditCardView = new BookAuditCardView();
            bookAuditCardView.bookAuditCardList = await bookAuditCardView.GetBookAuditCardsAsync($"api/libbookauditcards");
            bookAuditCardView.BookAuditCardDataGrid.ItemsSource = bookAuditCardView.bookAuditCardList;
            return bookAuditCardView;
        }

        public BookAuditCardView()
        {
            InitializeComponent();

            BookAuditCardDataGrid.Focus();
            //Get bookAuditCards from database
            bookAuditCardList = new List<LibBookAuditCard>();
            bookAuditCardList.Add(new LibBookAuditCard("902920", 0, 0, "029303"));
            bookAuditCardList.Add(new LibBookAuditCard("904859", 0, 0, "024567"));
            bookAuditCardList.Add(new LibBookAuditCard("924567", 0, 0, "029456"));
            BookAuditCardDataGrid.ItemsSource = bookAuditCardList;
        }

        private async Task<List<LibBookAuditCard>> GetBookAuditCardsAsync(string path) {
            List<LibBookAuditCard> bookAuditCards = null;
            var response = await App.Client.GetAsync(path);
            if (response.IsSuccessStatusCode) bookAuditCards = await response.Content.ReadAsAsync<List<LibBookAuditCard>>();
            return bookAuditCards;
        }

        private void BookAuditCardDataGrid_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            selectedBookAuditCard = BookAuditCardDataGrid.SelectedItem as LibBookAuditCard;
        }
    }
}
