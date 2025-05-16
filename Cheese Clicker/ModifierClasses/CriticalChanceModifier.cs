using System.Text;
using System.Xml.Serialization;

namespace Cheese_Clicker.ModifierClasses
{
    public class CriticalChanceModifier : Modifiers
    {
        private int additiveCriticalPercentChance = 20; // plus 20 percent critical chance on base

        [XmlElement("ModifierName")]
        public override string name { get; set; } = "Critical Chance Modifier";

        public override int GetModifierValue()
        {
            return additiveCriticalPercentChance;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(name + ": ");
            builder.AppendLine("+ " + additiveCriticalPercentChance + "%");
            return builder.ToString();
        }
    }
}
