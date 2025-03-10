using Cheese_Clicker.PlayerClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Cheese_Clicker.Pages
{
    /// <summary>
    /// Interaction logic for LauncherPage.xaml
    /// </summary>
    public partial class LauncherPage : Page
    {
        Player player;
        Window launcherWindow;
        public LauncherPage(Player inGameState, Window inLauncherWindow)
        {
            InitializeComponent();
            player = inGameState;
            launcherWindow = inLauncherWindow;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow window = new GameWindow(player);
            window.Visibility = Visibility.Visible;
            launcherWindow.Close();
        }

        private void PatchNotesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatchNotesPage());
        }
    }
}
