using Cheese_Clicker.Pages;
using Cheese_Clicker.PlayerClasses;
using System.Windows;

namespace Cheese_Clicker;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class GameWindow : Window
{   
    public GameWindow(Player inPlayer)
    {
        InitializeComponent();
        MainFrame.Visibility = Visibility.Visible;
        MainFrame.Navigate(new GamePage(inPlayer));
    }

}
