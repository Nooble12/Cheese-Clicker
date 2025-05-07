using Cheese_Clicker.Pages;
using Cheese_Clicker.PlayerClasses;
using System.Windows;
using System.Windows.Controls;

namespace Cheese_Clicker.ModifierClasses
{
    /// <summary>
    /// Interaction logic for MasteryRankResultPage.xaml
    /// </summary>
    public partial class MasteryRankResultPage : Page
    {
        private Player player;
        public MasteryRankResultPage(Player inPlayer)
        {
            InitializeComponent();
            player = inPlayer;
            DisplayResults();
        }

        public void BackToGamePageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GamePage(player));
        }

        private void DisplayResults()
        {
            MasteryRankLabel.Content = "Mastery Rank: " + player.statistics.masteryRankLevel;
            ResultsLabel.Content = player.modifierManager.GetRandomModifierResult().ToString();
        }
    }
}
