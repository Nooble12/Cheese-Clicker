using Cheese_Clicker.DataSaving;
using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.Pages;
using Cheese_Clicker.PlayerClasses;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cheese_Clicker.PlayerClasses;

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
