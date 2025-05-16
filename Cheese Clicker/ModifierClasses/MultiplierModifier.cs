using System.Text;
using System.Xml.Serialization;

namespace Cheese_Clicker.ModifierClasses
{
    public class MultiplierModifier : Modifiers
    {
        [XmlElement("ModifierName")]
        public override string name { get; set; } = "Multiplier Modifier";
        private int multiplierValue = 2; // 2 times
        private int duration = 10; // clicks

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
