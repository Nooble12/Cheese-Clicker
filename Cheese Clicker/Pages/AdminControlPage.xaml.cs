using Cheese_Clicker.Items;
using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.PlayerClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Cheese_Clicker.Pages
{
    /// <summary>
    /// Interaction logic for AdminControlPage.xaml
    /// </summary>
    public partial class AdminControlPage : Page
    {
        private Player player;
        public AdminControlPage(Player inGameState)
        {
            InitializeComponent();
            player = inGameState;
            UpdateUI();
        }

        private void GiveMultiplyMod_Click(object sender, RoutedEventArgs e)
        {
            Modifiers multiplyMod = new MultiplierModifier();
            player.modifierManager.AddModifier(multiplyMod);
        }

        private void GiveAddMod_Click(object sender, RoutedEventArgs e)
        {
            Modifiers modAdd = new AdditiveModifier();
            player.modifierManager.AddModifier(modAdd);
        }
        private void GiveCritChance_Click(object sender, RoutedEventArgs e)
        {
            Modifiers modAdd = new CriticalChanceModifier();
            player.modifierManager.AddModifier(modAdd);
        }
        private void GiveCritMultiply_Click(object sender, RoutedEventArgs e)
        {
            Modifiers modAdd = new CriticalMultiplierModifier();
            player.modifierManager.AddModifier(modAdd);
        }
        private void ClearAllMods_Click(object sender, RoutedEventArgs e)
        {
            player.modifierManager.ClearAllModifiers();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void GiveCheeseItem_Click(object sender, RoutedEventArgs e)
        {
            Item cheese = new CheeseItem();
            player.inventory.AddItem(cheese, 1);
            UpdateUI();
        }

        private void RemoveCheeseItem_Click(object sender, RoutedEventArgs e)
        {
            Item cheese = new CheeseItem();
            player.inventory.RemoveItem(cheese, 1);
            UpdateUI();
        }

        private void GiveComputerItem_Click(object sender, RoutedEventArgs e)
        {
            Item computer = new ComputerItem();
            player.inventory.AddItem(computer, 1);
            UpdateUI();
        }

        private void RemoveComputerItem_Click(object sender, RoutedEventArgs e)
        {
            Item computer = new ComputerItem();
            player.inventory.RemoveItem(computer, 1);
            UpdateUI();
        }

        private void UpdateUI()
        {
            InventoryLabel.Content = player.inventory.GetAllItemsAsString();
        }
    }
}
