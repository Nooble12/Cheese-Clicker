using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cheese_Clicker.ModifierClasses
{
    public class CriticalChanceModifier : Modifiers
    {
        private int additiveCriticalPercentChance = 20; // plus 20 percent critical chance on base
        private string name = "Critical Chance Modifier";

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
