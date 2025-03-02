using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_Clicker.ModifierClasses
{
    public class ModifierManager
    {
        private List<Modifiers> modifierList = new List<Modifiers>();

        private int totalAdditiveValue = 0;
        private int totalMultiplyValue = 1;

        public void AddModifier(Modifiers inModifier)
        {
            modifierList.Add(inModifier);
            
            if (inModifier is AdditiveModifier additive)
            {
                totalAdditiveValue += inModifier.GetModifierValue();
            }

            if (inModifier is MultiplierModifier multiplier)
            {
                totalMultiplyValue *= inModifier.GetModifierValue();
            }
        }

        public int ApplyAllModifiers(int moneyAmount)
        {
            int finalMoneyGained = (moneyAmount + totalAdditiveValue) * totalMultiplyValue;

            return finalMoneyGained;
        }

        public string GetModifierList()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var mod in modifierList)
            {
                builder.Append(mod);
            }
            return builder.ToString();
        }

    }
}
