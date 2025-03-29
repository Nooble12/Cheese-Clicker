using Cheese_Clicker.PlayerClasses;
using Cheese_Clicker.SoundClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Cheese_Clicker
{
    /// <summary>
    /// Interaction logic for ShopMenu.xaml
    /// </summary>
    public partial class ShopMenu : Page
    {
        private Player player;
        public ShopMenu(Player inPlayer)
        {
            InitializeComponent();
            //Visibility = Visibility.Visible;
            player = inPlayer;

            setUIElements();
        }

        private void ShopBackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.GoBack();
        }

        private void setUIElements()
        {
            balanceLabel.Content = "Balance: $" + player.statistics.money;
        }
    }
}
