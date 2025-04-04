﻿using Cheese_Clicker.Animations;
using Cheese_Clicker.Generators;
using Cheese_Clicker.PlayerClasses;
using Cheese_Clicker.SoundClasses;
using System.Windows;
using System.Windows.Controls;
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
        }

        private void CheeseButton_Click(object sender, RoutedEventArgs e)
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
            //BounceElement element = new(shopButton);
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.Navigate(new ShopMenu(player));
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
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.Navigate(new AdminControlPage(player));
        }
        private void GamePage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateModList(); // Refresh on navigation back
            UpdateMoneyLabel();
        }

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.Navigate(new InventoryPage(player));
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.Navigate(new SettingsPage());
        }

        private void UpdateMoneyLabel()
        {
            MoneyLabel.Content = $"Money: ${player.statistics.money:N0}";
        }
    }
}
