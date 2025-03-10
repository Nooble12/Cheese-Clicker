using Cheese_Clicker.PlayerClasses;
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
using Cheese_Clicker.PlayerClasses;

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
