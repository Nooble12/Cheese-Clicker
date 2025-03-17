using Cheese_Clicker.Generators;
using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.PlayerClasses;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Cheese_Clicker.Items
{
   public class ComputerItem : Item
    {
        [XmlElement("ItemName")]
        public override string name { get; set; } = "Computer";

        [XmlElement("ItemDescription")]
        public override string description { get; set; } = "A computer";

        [XmlElement("ItemPurchasePrice")]
        public override int purchasePrice { get; set; } = 2000;

        [XmlElement("ItemSellPrice")]
        public override int sellPrice { get; set; } = 1000;

        [XmlElement("WinChance")]
        public override int winChance { get; set; } = 80; //percent

        [XmlIgnore]
        public override string imagePath { get; set; } = "cheese_ghost.png";

        [XmlIgnore]
        public override string useItemMessage { get; set; } = "Computer";

        public override void UseItem(Player playerData)
        {
            Debug.WriteLine(name + " used!");

            RandomOutcome generator = new RandomOutcome(winChance);

            bool isWin = generator.GetOutcome();

            if (isWin)
            {
                ApplyItemBuff(playerData);
                useItemMessage = "You used a " + name + "\n" + "+ " + " 2x " + " Final Multiplier";
            }
            else
            {
                useItemMessage = "While using a " + name + " it exploded!" + "\n" + "All item modifiers removed!";
                ClearItemBuff(playerData);
            }
        }

        private void ApplyItemBuff(Player player)
        {
            Modifiers computerMod = new ComputerItemModifier();

            player.modifierManager.AddModifier(computerMod);
        }

        private void ClearItemBuff(Player player)
        {
            player.modifierManager.ResetAllItemBuffs();
        }
    }
}
