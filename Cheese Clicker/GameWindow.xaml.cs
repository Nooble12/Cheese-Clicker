using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.Pages;
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

namespace Cheese_Clicker;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class GameWindow : Window
{
    private PlayerData player = new PlayerData(1000);
    private ModifierManager modifiers = new ModifierManager();
    public GameWindow()
    {
        InitializeComponent();
        MainFrame.Visibility = Visibility.Visible;
        MainFrame.Navigate(new GamePage(player, modifiers));
    }
   
}
