using Cheese_Clicker.PlayerClasses;
using Cheese_Clicker.SoundClasses;
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
        }

        private void DisplayPlayerStats()
        {
            CurrentMoneyLabel.Content = $"Money: ${player.statistics.money:N0}";
            TotalClicksLabel.Content = $"Clicks: {player.statistics.clickCount:N0}";
            TotalMoneyGainedLabel.Content = $"Total Money Gained: {player.statistics.totalMoneyGained:N0}";
            MasteryRankLabel.Content = "Mastery Rank: " + player.statistics.masteryRankLevel;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.GoBack();
        }
    }
}
