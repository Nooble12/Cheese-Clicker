using Cheese_Clicker.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cheese_Clicker.Player
{
    public class InventoryEntry
    {
        [XmlElement("Item")]
        public Item Item { get; set; }

        [XmlElement("Quantity")]
        public int Quantity { get; set; }
    }

}
