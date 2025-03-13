using Cheese_Clicker.Items;
using Cheese_Clicker.PlayerClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
            rowCount = (player.inventory.GetInventorySize() + columns - 1) / columns;
            InsertButtons();
            ItemInfoGrid.Visibility = Visibility.Hidden;
        }

        private void CreateRowAndColumns()
        {
            InventoryGrid.ColumnDefinitions.Clear();
            InventoryGrid.RowDefinitions.Clear();

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
                if (column > 1)
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

        private void SellAllButton_Clicked(object sender, RoutedEventArgs e)
        {
            long totalInventoryValue = 0;

            foreach (var item in player.inventory.GetInventoryAsDictionary())
            {
                totalInventoryValue += item.Key.sellPrice;
            }
            Debug.WriteLine("Total Money: " + totalInventoryValue);
            player.statistics.AddMoney(totalInventoryValue);
            player.inventory.ClearInventory();
            Debug.WriteLine("Current Balance: " + player.statistics.money);
            DeleteAllInventoryButtons();
            LoadInventory();
        }

        private void UpdateItemInfoGrid(Item inItem)
        {
            ItemInfoGrid.Visibility = Visibility.Visible;
            ItemDescLabel.Content = (inItem.description + "\n" + "Sell Price: $" + inItem.sellPrice);
            ItemNameLabel.Content = inItem.name;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
