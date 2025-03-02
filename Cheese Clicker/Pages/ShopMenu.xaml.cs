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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cheese_Clicker
{
    /// <summary>
    /// Interaction logic for ShopMenu.xaml
    /// </summary>
    public partial class ShopMenu : Page
    {
        private PlayerData player;
        public ShopMenu(PlayerData inPlayer)
        {
            InitializeComponent();
            //Visibility = Visibility.Visible;
            player = inPlayer;

            setUIElements();
        }

        private void ShopBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void setUIElements()
        {
            balanceLabel.Content = "Balance: $" + player.GetMoney();
        }
    }
}
