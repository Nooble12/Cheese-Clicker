using Cheese_Clicker.Animations;
using Cheese_Clicker.Generators;
using Cheese_Clicker.ModifierClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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

namespace Cheese_Clicker.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private PlayerData player;
        private ModifierManager modifierManager;
        public GamePage(PlayerData player, ModifierManager manager)
        {
            InitializeComponent();
            this.player = player;
            this.modifierManager = manager;
            UpdateUI(player.GetMoney());
            UpdateModList();

            this.Loaded += GamePage_Loaded; // Ensure updates when returning
        }

        private void CheeseButton_Click(object sender, RoutedEventArgs e)
        {
            BounceElement element = new(cheeseButton);

            RandomMoneyGenerator generator = new RandomMoneyGenerator(1,100);

            int moneyGained = modifierManager.ApplyAllModifiers(generator.GetRandomMoney());
            player.AddMoney(moneyGained);

            player.IncrementClickCount();
            UpdateUI(moneyGained);

            MoneyLabelEffect effect = new MoneyLabelEffect(this, cheeseButton, moneyGained);
        }

        private void ShopButton_Click(object sender, RoutedEventArgs e)
        {
            //BounceElement element = new(shopButton);
            NavigationService.Navigate(new ShopMenu(player));
        }

        private void UpdateUI(int moneyGained)
        {
            cheeseButton.Content = ("$" + moneyGained);
            MoneyLabel.Content = ("Money: $" + player.GetMoney());
            ClickCountLabel.Content = ("Clicks: " + player.GetClickCount());
        }
        private void UpdateModList()
        {
            ModifierLabel.Content = modifierManager.GetModifierList();
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminControlPage(modifierManager));
        }
        private void GamePage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateModList(); // Refresh on navigation back
        }
    }
}
