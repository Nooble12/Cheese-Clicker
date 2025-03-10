using Cheese_Clicker.Items;
using System.Xml.Serialization;

namespace Cheese_Clicker.PlayerClasses
{
    public class InventoryEntry
    {
        [XmlElement("Item")]
        public Item Item { get; set; }

        [XmlElement("Quantity")]
        public int Quantity { get; set; }
    }

}
