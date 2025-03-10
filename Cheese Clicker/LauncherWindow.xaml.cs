using Cheese_Clicker.Pages;
using Cheese_Clicker.PlayerClasses;
using System.Windows;

namespace Cheese_Clicker
{
    /// <summary>
    /// Interaction logic for LauncherWindow.xaml
    /// </summary>
    public partial class LauncherWindow : Window
    {
        public LauncherWindow(Player inPlayer)
        {
            InitializeComponent();
            LauncherWin.Visibility = Visibility.Visible;
            LauncherWin.Navigate(new LauncherPage(inPlayer, this));
        }
    }
}