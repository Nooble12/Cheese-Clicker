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
using System.IO;
using System.Diagnostics;
using Cheese_Clicker.ModifierClasses;
using System.Threading.Channels;
using Cheese_Clicker.Pages;

namespace Cheese_Clicker.DataSaving
{
    /// <summary>
    /// Interaction logic for SelectProfileWindow.xaml
    /// </summary>
    public partial class SelectProfileWindow : Page
    {
        private string saveFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFiles");
        private string selectedFile = "N/A";
        private PlayerData player;
        private ModifierManager modifiers;
        public SelectProfileWindow(PlayerData inPlayer, ModifierManager inMod)
        {
            InitializeComponent();
            LoadFileList();

            player = inPlayer;
            modifiers = inMod;
        }

        private void LoadFileList()
        {
            string[] files = Directory.GetFiles(saveFolderPath);

            foreach (string file in files)
            {
                FileListBox.Items.Add(Path.GetFileName(file));
            }
        }
        private void searchBox_Changed(object sender, EventArgs e)
        {
            //Ignores the initial text changed on window start
            if (SearchBox.Text.Equals("Search Here"))
            {
                return;
            }
            DisplaySearchedFile(SearchBox.Text);
        }

        private void DisplaySearchedFile(String inSearch)
        {
            string[] files = Directory.GetFiles(saveFolderPath);

            FileListBox.Items.Clear();

            foreach (string file in files)
            {
                if (Path.GetFileName(file).IndexOf(inSearch, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    FileListBox.Items.Add(Path.GetFileName(file));
                }
            }
        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (FileListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a file to load.");
                return;
            }

            string selectedFile = FileListBox.SelectedItem.ToString();
            Debug.WriteLine("Selected file: " + selectedFile);
            string fullPath = Path.Combine(saveFolderPath, selectedFile);

            try
            {
                string fileContent = File.ReadAllText(fullPath);
                MessageBox.Show($"File loaded: {fullPath}\nContent:\n{fileContent}");
                selectedFile = fullPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load file: {ex.Message}");
            }
        }
        public string GetSelectedSaveFile()
        {
            return selectedFile;
        }
    }
}
