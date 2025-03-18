using Cheese_Clicker.Generators;
using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.PlayerClasses;
using System.Diagnostics;
using System.IO;
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

        [XmlElement("WinChance")]
        public override int winChance { get; set; } = 50; //percent

        [XmlIgnore]
        public override string imagePath { get; set; } = "cheese_ghost.png";

        [XmlIgnore]
        public override string useItemMessage { get; set; }

        public override void UseItem(Player playerData)
        {
            Debug.WriteLine(name + " used!");

            RandomOutcome generator = new RandomOutcome(winChance);

            bool isWin = generator.GetOutcome();

            if (isWin)
            {
                ApplyItemBuff(playerData);
                useItemMessage = "You ate a piece of " + name + "\n" + "+ " + " 4x " + " Final Multiplier";
            }
            else
            {
                useItemMessage = "You ate a piece of " + name + " and died!" + "\n" + "All item modifiers removed!";
                ClearItemBuff(playerData);
            }
        }

        private void ApplyItemBuff(Player player)
        {
            Modifiers cheeseMod = new CheeseItemModifier();

            player.modifierManager.AddModifier(cheeseMod);
        }

        private void ClearItemBuff(Player player)
        {
            player.modifierManager.ResetAllItemModifiers();
        }

    }
}