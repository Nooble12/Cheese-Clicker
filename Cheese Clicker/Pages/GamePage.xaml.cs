using Cheese_Clicker.Animations;
using Cheese_Clicker.Generators;
using Cheese_Clicker.PlayerClasses;
using Cheese_Clicker.SoundClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

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

        private GenerateReward rewardGenerator;
        public GamePage(Player inPlayer)
        {
            InitializeComponent();
            player = inPlayer;
            UpdateStatisticsUI(player.statistics.money);
            UpdateModList();
            this.Loaded += GamePage_Loaded; // Ensure updates when returning

            rewardGenerator = new GenerateReward(player);
            moneyLabelEffect = new MoneyLabelEffect(this);

            //For keyboard related presses
            this.Focusable = true;
            this.Focus();
            this.KeyDown += Keyboard_KeyDown;
        }

        private void CheeseButton_Click(object sender, RoutedEventArgs e)
        {
            ActivateCheeseButton();
        }

        private void Keyboard_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    ActivateCheeseButton();
                break;
                    
                case Key.D1:
                    DisplayPage(new ShopMenu(player));
                break;

                case Key.D2:
                    DisplayPage(new InventoryPage(player));
                break;

                case Key.D3:
                    DisplayPage(new PlayerStatisticsPage(player));
                break;

                case Key.Escape:
                    DisplayPage(new SettingsPage());
                break;
            }
        }

        //On cheese button click or space bar keybind
        private void ActivateCheeseButton()
        {
            Reward reward = rewardGenerator.GetReward();
            player.statistics.AddMoney(reward.moneyGained);

            player.statistics.IncrementClickCount();
            UpdateStatisticsUI(reward.moneyGained);

            SoundManager.PlaySound(SoundEffects.Click);

            bounceElement.PlayAnimation(cheeseButton, 2, 0.1);

            moneyLabelEffect.PlayAnimation(reward);
        }
        private void ShopButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayPage(new ShopMenu(player));
        }

        private void UpdateStatisticsUI(long moneyGained)
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
            DisplayPage(new AdminControlPage(player));
        }

        private void GamePage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateModList(); // Refresh on navigation back
            UpdateMoneyLabel();
        }

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            DisplayPage(new InventoryPage(player));
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            DisplayPage(new SettingsPage());
        }

        private void PlayerStatsButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayPage(new PlayerStatisticsPage(player));
        }

        private void UpdateMoneyLabel()
        {
            MoneyLabel.Content = $"Money: ${player.statistics.money:N0}";
        }

        private void DisplayPage(Page page)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.Navigate(page);
        }
    }
}
