using System.Text;
using System.Xml.Serialization;

namespace Cheese_Clicker.Items
{
    [XmlInclude(typeof(CheeseItem))]
    [XmlInclude(typeof(ComputerItem))]
    public class Item
    {
        [XmlElement("ItemName")]
        public virtual string name { get; set; }

        [XmlElement("ItemDescription")]
        public virtual string description { get; set; }

        [XmlElement("ItemPurchasePrice")]
        public virtual int purchasePrice { get; set; }

        [XmlElement("ItemSellPrice")]
        public virtual int sellPrice { get; set; }

        [XmlElement("ItemUseValue")]
        public virtual long useValue { get; set; }
        public virtual void UseItem()
        {

        }

        public virtual string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Name: " + name);
            builder.AppendLine("Description: " + description);
            builder.AppendLine("Price: " + purchasePrice);
            builder.AppendLine("Sell Price: " + sellPrice);
            return builder.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is Item other)
            {
                return 
                    name == other.name 
                    && description == other.description 
                    && sellPrice == other.sellPrice 
                    && purchasePrice == other.purchasePrice;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode(); 
        }
    }
}
