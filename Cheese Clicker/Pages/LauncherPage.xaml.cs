using Cheese_Clicker.Player;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for LauncherPage.xaml
    /// </summary>
    public partial class LauncherPage : Page
    {
        GameState playerGameState;
        Window launcherWindow;
        public LauncherPage(GameState inGameState, Window inLauncherWindow)
        {
            InitializeComponent();
            playerGameState = inGameState;
            launcherWindow = inLauncherWindow;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow window = new GameWindow(playerGameState);
            window.Visibility = Visibility.Visible;
            launcherWindow.Close();
        }

        private void PatchNotesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatchNotesPage());
        }
    }
}
