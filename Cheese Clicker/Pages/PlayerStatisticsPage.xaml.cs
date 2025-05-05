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
        public PlayerStatisticsPage(Player inPlayer)
        {
            InitializeComponent();
            player = inPlayer;
            DisplayPlayerStats();
            CheckMasteryRankEligibility();
        }

        private void DisplayPlayerStats()
        {
            CurrentMoneyLabel.Content = $"Money: ${player.statistics.money:N0}";
            TotalClicksLabel.Content = $"Clicks: {player.statistics.clickCount:N0}";
            TotalMoneyGainedLabel.Content = $"Total Money Gained: ${player.statistics.totalMoneyGained:N0}";
            MasteryRankLabel.Content = "Mastery Rank: " + player.statistics.masteryRankLevel;
            MasteryRankRequirementLabel.Content = $"Requirement: ${player.statistics.money:N0} / ${GetMasteryRankEligibilityRequirement():N0} ({GetMasteryRankPercent():N0}%)";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.GoBack();
        }

        private void CheckMasteryRankEligibility()
        {
           if (player.statistics.money >= GetMasteryRankEligibilityRequirement())
            {
                MasteryRankButton.Visibility = Visibility.Visible;
            }

        }

        private float GetMasteryRankPercent()
        {
            float percent =((float)player.statistics.money / GetMasteryRankEligibilityRequirement()) * 100.0f;
            return percent;
        }

        private long GetMasteryRankEligibilityRequirement()
        {
            double baseValue = 10;
            long baseMasteryRankRequirement = 1000000; // To rank up to level 1
            return (long)Math.Pow(baseValue, player.statistics.masteryRankLevel/ 6.0) * baseMasteryRankRequirement;
        }
    }
}
