﻿using Cheese_Clicker.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cheese_Clicker.Player
{
    [XmlRoot("PlayerInventory")]
    public class Inventory
    {
        [XmlArray("InventoryDictionary")]
        [XmlArrayItem("ItemEntry")]
        public List<InventoryEntry> InventoryEntries { get; set; } = new List<InventoryEntry>();

        [XmlIgnore]
        private Dictionary<Item, int> playerInventory = new Dictionary<Item, int>();

        //Converts to a list for xml
        public void PrepareForSerialization()
        {
            InventoryEntries.Clear();
            foreach (var entry in playerInventory)
            {
                InventoryEntries.Add(new InventoryEntry { Item = entry.Key, Quantity = entry.Value });
            }
        }
        //Converts the list to dictionary
        public void PrepareAfterDeserialization()
        {
            playerInventory.Clear();
            foreach (var entry in InventoryEntries)
            {
                playerInventory.Add(entry.Item, entry.Quantity);
            }
        }

        public void AddItem(Item inItem, int inAmount)
        {
            if (playerInventory.ContainsKey(inItem))
            {
                playerInventory[inItem] += inAmount;
            }
            else
            {
                playerInventory[inItem] = inAmount;
            }
        }

        public void RemoveItem(Item item, int quantity)
        {
            if (playerInventory.ContainsKey(item))
            {
                if (playerInventory[item] > quantity)
                {
                    playerInventory[item] -= quantity;
                }
                else
                {
                    playerInventory.Remove(item);
                }
            }
            else
            {
                Debug.WriteLine("Error, could not remove: " + item.name + " because it does not exist in inventory.");
            }
        }

        public string GetAllItemsAsString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in playerInventory)
            {
                builder.AppendLine(item.Key.name + ": " + item.Value);
            }
            return builder.ToString();
        }

        public int GetItemQuantity(Item inItem)
        {
            if (playerInventory.ContainsKey(inItem))
            {
                return playerInventory[inItem];
            }
            else
            {
                Debug.WriteLine("Error, could not find item");
                return 0;
            }
        }
        public void ClearInventory()
        {
            playerInventory.Clear();
        }

        public List<InventoryEntry> GetInventoryEntriesList()
        {
            return InventoryEntries;
        }
    }
}
