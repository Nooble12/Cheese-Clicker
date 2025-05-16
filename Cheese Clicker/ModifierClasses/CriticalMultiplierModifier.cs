using System.Text;
using System.Xml.Serialization;

namespace Cheese_Clicker.ModifierClasses
{
    public class CriticalMultiplierModifier : Modifiers
    {
        private int multiplierValue = 2;

        [XmlElement("ModifierName")]
        public override string name { get; set; } = "Critical Multiplier Modifier";

        public override int GetModifierValue()
        {
            return multiplierValue;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(name + ": ");
            builder.AppendLine("+ " + multiplierValue + "x");
            return builder.ToString();
        }
    }
}
