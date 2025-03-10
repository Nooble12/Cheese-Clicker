using System.Xml.Serialization;

namespace Cheese_Clicker.Items
{
   public class CheeseItem : Item
    {
        [XmlElement("ItemName")]
        public override string name { get; set; } = "Cheese";

        [XmlElement("ItemDescription")]
        public override string description { get; set; } = "A yellow piece of cheese";

        [XmlElement("ItemPurchasePrice")]
        public override int purchasePrice { get; set; } = 1000;

        [XmlElement("ItemSellPrice")]
        public override int sellPrice { get; set; } = 800;

        public override void UseItem()
        {

        }

    }
}