using System.Text;
using System.Xml.Serialization;

namespace Cheese_Clicker.ModifierClasses
{
    public class AdditiveModifier : Modifiers
    {
        [XmlElement("ModifierName")]
        public override string name { get; set; } = "Additive Modifier";
        private int additiveValue = 100;

        public override int GetModifierValue()
        {
            return additiveValue;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(name + ": ");
            builder.AppendLine("+ $" + additiveValue);
            return builder.ToString();
        }

    }
}
