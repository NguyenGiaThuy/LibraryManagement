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
using Client.Views.Main.Features.Dialogs;
using Microsoft.Win32;

namespace Client.Views.Main.Features
{
    /// <summary>
    /// Interaction logic for MemberView.xaml
    /// </summary>
    public partial class MemberView : Window
    {
        public MemberView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void MemberNewBtn_Click(object sender, RoutedEventArgs e)
        {
            DecisionView decisionView = new DecisionView();
            decisionView.Title = "Adding new members";
            decisionView.DecisionContentTxt.Text = "What kind of adding do you want?";
            decisionView.IndividualBtn.Content = "Add by form";
            decisionView.MassBtn.Content = "Add from a file";
            decisionView.ShowDialog();
        }

        private void MemberUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            DecisionView decisionView = new DecisionView();
            decisionView.Title = "Updating members";
            decisionView.DecisionContentTxt.Text = "What kind of updating do you want?";
            decisionView.IndividualBtn.Content = "Individual update";
            decisionView.MassBtn.Content = "Mass update";
            decisionView.ShowDialog();
        }

        private void MemberRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            DecisionView decisionView = new DecisionView();
            decisionView.Title = "Removing members";
            decisionView.DecisionContentTxt.Text = "What kind of removing do you want?";
            decisionView.IndividualBtn.Content = "Individual remove";
            decisionView.MassBtn.Content = "Mass remove";
            decisionView.ShowDialog();
        }

        private void MemberReportBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export a report";
            saveFileDialog.FileName = "Member_Report";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.Filter = "CSV files (.csv)|*.csv";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.ValidateNames = true;
            saveFileDialog.ShowDialog();
        } 
    }
}
