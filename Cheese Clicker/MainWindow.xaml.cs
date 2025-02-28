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
    private PlayerData playerData = new PlayerData();
    public MainWindow()
    {
        InitializeComponent();
    }
    private void CheeseButton_Click(object sender, RoutedEventArgs e)
    {
        BounceElement element = new BounceElement(cheeseButton);
        playerData.AddMoney(1);

        MoneyLabel.Content = ("Money: " + playerData.GetMoney());
    }
}
