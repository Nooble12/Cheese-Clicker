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
public partial class MainWindow : Window
{
    private PlayerData player = new PlayerData(1000);
    public MainWindow()
    {
        InitializeComponent();
    }
    private void CheeseButton_Click(object sender, RoutedEventArgs e)
    {
        BounceElement element = new(cheeseButton);
        player.AddMoney(1);

        MoneyLabel.Content = ("Money: " + player.GetMoney());
    }

    private void ShopButton_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new ShopMenu(player));
    }
}
