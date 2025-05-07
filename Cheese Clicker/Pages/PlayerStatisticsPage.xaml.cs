using Cheese_Clicker.PlayerClasses;
using Cheese_Clicker.SoundClasses;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;


namespace Cheese_Clicker.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class PlayerStatisticsPage : Page
    {
        private Player player;
        private MasteryRankManager masteryRankManager;
        public PlayerStatisticsPage(Player inPlayer)
        {
            InitializeComponent();
            player = inPlayer;
            masteryRankManager = new MasteryRankManager(player);
            CheckMasteryRankButtonVisibility();
            DisplayPlayerStats();
        }

        private void DisplayPlayerStats()
        {
            CurrentMoneyLabel.Content = $"Money: ${player.statistics.money:N0}";
            TotalClicksLabel.Content = $"Clicks: {player.statistics.clickCount:N0}";
            TotalMoneyGainedLabel.Content = $"Total Money Gained: ${player.statistics.totalMoneyGained:N0}";
            MasteryRankLabel.Content = "Mastery Rank: " + player.statistics.masteryRankLevel;
            MasteryRankRequirementLabel.Content = $"Requirement: ${player.statistics.money:N0} / ${masteryRankManager.GetMasteryRankEligibilityRequirement():N0} ({masteryRankManager.GetMasteryRankPercent():N0}%)";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.GoBack();
        }
        private void MasteryRankButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.Navigate(new MasteryRankConfirmPage(masteryRankManager, player));
        }

        private void CheckMasteryRankButtonVisibility()
        {
            if (masteryRankManager.CheckMasteryRankEligibility())
            {
                MasteryRankButton.Visibility = Visibility.Visible;
            }
        }
    }
}
