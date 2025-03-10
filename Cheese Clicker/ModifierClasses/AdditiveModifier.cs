using System.Text;

namespace Cheese_Clicker.ModifierClasses
{
    public class AdditiveModifier : Modifiers
    {
        private string name = "Additive Modifier";
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
