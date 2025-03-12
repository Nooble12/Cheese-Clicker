using Cheese_Clicker.Items;
using Cheese_Clicker.PlayerClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            CreateRowAndColumns();
            rowCount = (player.inventory.GetInventorySize() + columns - 1) / columns;
            InsertButtons();
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
                btn.Click += (s, e) => HandleItemClick();
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

        private void HandleItemClick()
        {
            Debug.WriteLine("Clicked");
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
