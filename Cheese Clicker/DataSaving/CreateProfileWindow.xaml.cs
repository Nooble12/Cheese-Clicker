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

namespace Cheese_Clicker.DataSaving
{
    /// <summary>
    /// Interaction logic for CreateProfileWindow.xaml
    /// </summary>
    public partial class CreateProfileWindow : Window
    {
        String playerName = "N/A";
        public CreateProfileWindow()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            playerName = (String)ProfileNameLabel.Text;
            this.DialogResult = true;
        }

        public String GetProfileName()
        {
            return playerName;
        }
    }
}
