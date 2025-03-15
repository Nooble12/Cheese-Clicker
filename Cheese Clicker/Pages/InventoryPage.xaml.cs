using Cheese_Clicker.Animations;
using Cheese_Clicker.Generators;
using Cheese_Clicker.Items;
using Cheese_Clicker.PlayerClasses;
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
        private int columns = 3;
        private int rowCount;
        private Player player;
        public InventoryPage(Player inPlayer)
        {
            InitializeComponent();
            player = inPlayer;
            LoadInventory();
        }

        private void LoadInventory()
        {
            CreateRowAndColumns();
            InsertButtons();
            ItemInfoGrid.Visibility = Visibility.Hidden;
            UpdateTotalValueLabel();
            DetermineSellButtonVisibility();
        }

        private void CreateRowAndColumns()
        {
            InventoryGrid.ColumnDefinitions.Clear();
            InventoryGrid.RowDefinitions.Clear();
            rowCount = (player.inventory.GetInventorySize() + columns - 1) / columns;

            for (int i = 0; i < columns; i++)
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
                btn.Click += (s, e) => HandleItemClick(item.Key);
                Grid.SetRow(btn, row);
                Grid.SetColumn(btn, column);

                InventoryGrid.Children.Add(btn);

                column++;
                if (column > 2)
                {
                    column = 0;
                    row++;
                }

            }
        }

        private void HandleItemClick(Item inItem)
        {
            UpdateItemInfoGrid(inItem);
        }

        private void DeleteAllInventoryButtons()
        {
            var buttonsToRemove = InventoryGrid.Children.OfType<Button>().ToList();
            foreach (var button in buttonsToRemove)
            {
                InventoryGrid.Children.Remove(button);
            }
        }

        private void DetermineSellButtonVisibility()
        {
            if (player.inventory.GetInventorySize() > 0)
            {
                SellAllItemButton.Visibility = Visibility.Visible;
            }
            else
            {
                SellAllItemButton.Visibility = Visibility.Hidden;
            }
        }

        private void SellAllButton_Clicked(object sender, RoutedEventArgs e)
        {
            long totalInventorySellValue = player.inventory.GetTotalInventorySellValue();

            if (totalInventorySellValue > 0)
            {
                GenerateReward rewardGenerator = new GenerateReward(player);
                Reward reward = rewardGenerator.GetSellItemReward(totalInventorySellValue);

                MoneyLabelEffect labelEffect = new MoneyLabelEffect(this);
                labelEffect.PlayAnimation(reward);

                player.statistics.AddMoney(reward.moneyGained);
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
            NavigationService.GoBack();
        }
    }
}
