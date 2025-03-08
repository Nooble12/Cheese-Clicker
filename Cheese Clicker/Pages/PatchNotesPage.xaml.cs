﻿using Cheese_Clicker.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;


namespace Cheese_Clicker
{
    /// <summary>
    /// Interaction logic for PatchNotesPage.xaml
    /// </summary>
    public partial class PatchNotesPage : Page
    {
        private ReadTextFile processor;
        
        public PatchNotesPage()
        {
            InitializeComponent();
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(projectDirectory, "resources", "PatchNotes.txt");
            processor = new ReadTextFile(filePath);
            LoadTextBoxContents();
        }

        private void LoadTextBoxContents()
        {
            TextBox.Text = processor.ReadFile();
        }

        private void PatchNotesBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
