using Cheese_Clicker.Items;
using Cheese_Clicker.PlayerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseClickerTests
{
    public class InventoryTest
    {
        [Fact]
        public void Add_Item_To_Inventory()
        {
            Inventory playerInventory = new Inventory();
            Item computerItem = new ComputerItem();
            Item cheeseItem = new CheeseItem();

            playerInventory.AddItem(computerItem, 1);
            playerInventory.AddItem(computerItem, 2);
            playerInventory.AddItem(cheeseItem, 1);

            int actualComputerQuantity = playerInventory.GetItemQuantity(computerItem);
            int actualCheeseQuantity = playerInventory.GetItemQuantity(cheeseItem);

            Assert.Equal(1, actualCheeseQuantity);
            Assert.Equal(3, actualComputerQuantity);
        }

        [Fact]
        public void Remove_Item_From_Inventory()
        {
            Inventory playerInventory = new Inventory();
            Item computerItem = new ComputerItem();
            Item cheeseItem = new CheeseItem();

            playerInventory.AddItem(computerItem, 1);
            playerInventory.AddItem(computerItem, 2);
            playerInventory.AddItem(cheeseItem, 1);

            playerInventory.RemoveItem(computerItem, 2);
            playerInventory.RemoveItem(cheeseItem, 1);

            int actualComputerQuantity = playerInventory.GetItemQuantity(computerItem);
            int actualCheeseQuantity = playerInventory.GetItemQuantity(cheeseItem);

            Assert.Equal(0, actualCheeseQuantity);
            Assert.Equal(1, actualComputerQuantity);
        }

        [Fact]
        public void Test_PrepareForSerialization()
        {
            Inventory playerInventory = new Inventory();
            Item computerItem = new ComputerItem();
            Item cheeseItem = new CheeseItem();

            playerInventory.AddItem(computerItem, 1);
            playerInventory.AddItem(cheeseItem, 1);

            playerInventory.PrepareForSerialization();

            List<InventoryEntry> actualInventoryEntries = playerInventory.GetInventoryEntriesList();

            List<InventoryEntry> expectedInventoryEntries = new List<InventoryEntry>();

            Assert.Equal(computerItem, actualInventoryEntries[0].Item);
            Assert.Equal(1, actualInventoryEntries[0].Quantity);

            Assert.Equal(cheeseItem, actualInventoryEntries[1].Item);
            Assert.Equal(1, actualInventoryEntries[1].Quantity);
        }

        [Fact]
        public void Test_PrepareAfterDeserialization()
        {
            Inventory playerInventory = new Inventory();
            Item computerItem = new ComputerItem();
            Item cheeseItem = new CheeseItem();

            List<InventoryEntry> inventoryList = new List<InventoryEntry>();
            inventoryList.Add(new InventoryEntry { Item = computerItem, Quantity = 1 });
            inventoryList.Add(new InventoryEntry { Item = cheeseItem, Quantity = 1 });

            playerInventory.InventoryEntries = inventoryList;

            playerInventory.PrepareAfterDeserialization();

            Assert.Equal(1, playerInventory.GetItemQuantity(computerItem));
            Assert.Equal(1, playerInventory.GetItemQuantity(cheeseItem));

        }
    }
}
