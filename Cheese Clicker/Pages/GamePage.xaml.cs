using Cheese_Clicker.Animations;
using Cheese_Clicker.Generators;
using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.PlayerClasses;
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
        private Player player;
        private BounceElement bounceElement = new BounceElement();
        private MoneyLabelEffect moneyLabelEffect;

        private GenerateReward moneyGenerator;
        public GamePage(Player inPlayer)
        {
            InitializeComponent();
            player = inPlayer;
            UpdateUI(player.statistics.money);
            UpdateModList();
            this.Loaded += GamePage_Loaded; // Ensure updates when returning

            moneyGenerator = new GenerateReward(player);
            moneyLabelEffect = new MoneyLabelEffect(this);
        }

        private void CheeseButton_Click(object sender, RoutedEventArgs e)
        {
            long moneyGained = moneyGenerator.GetReward();
            player.statistics.AddMoney(moneyGained);

            player.statistics.IncrementClickCount();
            UpdateUI(moneyGained);

            bounceElement.PlayAnimation(cheeseButton);

            moneyLabelEffect.PlayAnimation(moneyGained);
        }

        private void ShopButton_Click(object sender, RoutedEventArgs e)
        {
            //BounceElement element = new(shopButton);
            NavigationService.Navigate(new ShopMenu(player));
        }

        private void UpdateUI(long moneyGained)
        {
            cheeseButton.Content = $"${moneyGained:N0}";
            MoneyLabel.Content = $"Money: ${player.statistics.money:N0}";
            ClickCountLabel.Content = $"Clicks: {player.statistics.clickCount:N0}";
        }
        private void UpdateModList()
        {
            ModifierLabel.Content = player.modifierManager.GetModifierListAsString();
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminControlPage(player));
        }
        private void GamePage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateModList(); // Refresh on navigation back
        }
    }
}
