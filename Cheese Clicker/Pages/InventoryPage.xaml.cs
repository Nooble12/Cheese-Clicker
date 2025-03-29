using Cheese_Clicker.Animations;
using Cheese_Clicker.Generators;
using Cheese_Clicker.Items;
using Cheese_Clicker.PlayerClasses;
using Cheese_Clicker.SoundClasses;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Cheese_Clicker.Pages
{
    /// <summary>
    /// Interaction logic for InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        private int columnCount = 3;
        private int rowCount;
        private Player player;
        private BounceElement bounceElement = new BounceElement();
        private Item selectedItem = null;
        public InventoryPage(Player inPlayer)
        {
            InitializeComponent();
            player = inPlayer;
            LoadInventory();
        }

        private void LoadInventory()
        {
            DeleteAllInventoryButtons();
            CreateRowAndColumns();
            InsertButtons();
            ItemInfoGrid.Visibility = Visibility.Hidden;
            UpdateTotalValueLabel();
            DetermineUIVisibility();
        }

        private void CreateRowAndColumns()
        {
            InventoryGrid.ColumnDefinitions.Clear();
            InventoryGrid.RowDefinitions.Clear();
            rowCount = (player.inventory.GetInventorySize() + columnCount - 1) / columnCount;

            for (int i = 0; i < columnCount; i++)
            {
                InventoryGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < rowCount; i++)
            {
                InventoryGrid.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void InsertButtons() 
        {
            int column = 0;
            int row = 0;
            foreach (var item in player.inventory.GetInventoryAsDictionary())
            {
                Button btn = new Button();
                btn.Content = item.Value + " " + item.Key.name;
                btn.Click += (s, e) => HandleItemClick(item.Key, btn);
                btn.Margin = new Thickness(3);
                Grid.SetRow(btn, row);
                Grid.SetColumn(btn, column);

                InventoryGrid.Children.Add(btn);

                column++;
                if (column >= columnCount)
                {
                    column = 0;
                    row++;
                }

            }
        }

        private void HandleItemClick(Item inItem, Button button)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            AssignSelectedItem(inItem);
            UpdateItemInfoGrid(inItem);
            bounceElement.PlayAnimation(button, 1.08, 0.08);
        }

        private void AssignSelectedItem(Item inItem)
        {
            selectedItem = inItem;
        }

        private void DeselectItem()
        {
            selectedItem = null;
        }

        private void DeleteAllInventoryButtons()
        {
            var buttonsToRemove = InventoryGrid.Children.OfType<Button>().ToList();
            foreach (var button in buttonsToRemove)
            {
                InventoryGrid.Children.Remove(button);
            }
        }

        private void DetermineUIVisibility()
        {
            if (player.inventory.GetInventorySize() > 0)
            {
                SellAllItemButton.Visibility = Visibility.Visible;
                InventoryScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
            else
            {
                SellAllItemButton.Visibility = Visibility.Hidden;
                InventoryScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
        }

        private void SellAllButton_Clicked(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            long totalInventorySellValue = player.inventory.GetTotalInventorySellValue();
            DeselectItem();

            if (totalInventorySellValue > 0)
            {
                SellItem(totalInventorySellValue);
                player.inventory.ClearInventory();
                DeleteAllInventoryButtons();
                SellAllItemButton.Visibility = Visibility.Hidden;
                LoadInventory();
            }
            else
            {
                Debug.WriteLine("Error, could not sell empty inventory");
            }
        }

        private void SellItem(long itemSellValue)
        {
            GenerateReward rewardGenerator = new GenerateReward(player);
            Reward reward = rewardGenerator.GetSellItemReward(itemSellValue);
            player.statistics.AddMoney(reward.moneyGained);
            MoneyLabelEffect labelEffect = new MoneyLabelEffect(this);
            labelEffect.PlayAnimation(reward);
        }

        private void SellSingleItem_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            int selectedItemSellValue = selectedItem.sellPrice;
            SellItem(selectedItemSellValue);
            player.inventory.RemoveItem(selectedItem, 1);
            LoadInventory();
        }

        private void UseItem_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            bounceElement.PlayAnimation(UseItemButton, 1.08, 0.08);

            if(selectedItem != null)
            {
                player.inventory.RemoveItem(selectedItem, 1);
                NavigationService.Navigate(new UseItemPage(selectedItem, player));
                LoadInventory();
                DeselectItem();
            }
            else
            {
                Debug.WriteLine("Error, could not find item");
            }
        }

        private void UpdateItemInfoGrid(Item inItem)
        {
            ItemInfoGrid.Visibility = Visibility.Visible;
            ItemDescLabel.Content = (inItem.description + "\n" + "Sell Price: $" + inItem.sellPrice);
            ItemNameLabel.Content = inItem.name;

            try
            {
                ItemImage.Source = new BitmapImage(new Uri(inItem.GetImagePath()));
            }catch(IOException e)
            {
                Debug.WriteLine("Error, could not load image");
            }
        }

        public void UpdateTotalValueLabel()
        {
            long totalValue = player.inventory.GetTotalInventorySellValue();
            InventoryValueLabel.Content = "Total Inventory Value: " + $"${player.inventory.GetTotalInventorySellValue():N0}";
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.GoBack();
        }
    }
}
