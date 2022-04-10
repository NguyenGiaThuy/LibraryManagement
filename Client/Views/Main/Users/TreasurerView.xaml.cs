﻿using System;
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

namespace Client.Views.Main.Users {
    /// <summary>
    /// Interaction logic for TreasurerView.xaml
    /// </summary>
    public partial class TreasurerView : Window {
        public TreasurerView() {
            InitializeComponent();
        }

        //Close properly the app when the exit button is pressed
        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
