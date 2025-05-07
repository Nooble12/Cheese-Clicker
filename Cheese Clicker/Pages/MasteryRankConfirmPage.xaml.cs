using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.PlayerClasses;
using Cheese_Clicker.SoundClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Cheese_Clicker.Pages
{
    /// <summary>
    /// Interaction logic for MasteryRankConfirmPage.xaml
    /// </summary>
    public partial class MasteryRankConfirmPage : Page
    {
        private MasteryRankManager manager;
        private Player player;
        public MasteryRankConfirmPage(MasteryRankManager inManager, Player inPlayer)
        {
            InitializeComponent();
            manager = inManager;
            player = inPlayer;
        }

        private void CommitButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            manager.RankUpMastery();
            NavigationService.Navigate(new MasteryRankResultPage(player));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.GoBack();
        }
    }
}
