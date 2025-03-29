using Cheese_Clicker.Items;
using Cheese_Clicker.PlayerClasses;
using Cheese_Clicker.SoundClasses;
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
    /// Interaction logic for UseItemPage.xaml
    /// </summary>
    public partial class UseItemPage : Page
    {
        private Item selectedItem;
        private Player player;
        public UseItemPage(Item item, Player playerData)
        {
            InitializeComponent();
            selectedItem = item;
            player = playerData;
            SelectedItemLabel.Content = item.name;
            UseItem();
        }

        private void UseItem()
        {
            selectedItem.UseItem(player);
            UseItemMessage.Content = selectedItem.useItemMessage;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.GoBack();
        }
    }
}
