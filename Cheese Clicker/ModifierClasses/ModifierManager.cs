using System;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cheese_Clicker.ModifierClasses
{
    [XmlRoot("ModifierManager")]
    public class ModifierManager
    {
        [XmlElement("ModifierList")]
        public List<Modifiers> modifierList = new List<Modifiers>();

        private Random generator = new Random();

        private int totalAdditiveValue = 0;
        private int totalMultiplyValue = 1;
        private int totalCritChance = 10; //percent
        private int totalCritMultiplier = 2;

        public void AddModifier(Modifiers inModifier)
        {
            modifierList.Add(inModifier);

            CalculateStats(inModifier);
        }

        private void CalculateStats(Modifiers inModifier)
        {
            switch (inModifier)
            {
                case AdditiveModifier additiveMod:
                    totalAdditiveValue += inModifier.GetModifierValue();
                    break;

                case MultiplierModifier multiplyMod:
                    totalMultiplyValue *= inModifier.GetModifierValue();
                    break;

                case CriticalChanceModifier critChanceMod:
                    totalCritChance += inModifier.GetModifierValue();
                    break;

                case CriticalMultiplierModifier critMultiplierMod:
                    totalCritMultiplier += inModifier.GetModifierValue();
                    break;
            }
        }

        //Only runs on game start up
        public void ReCalculateAllStats()
        {
            foreach (var modifier in modifierList)
            {
                int totalAdditiveValue = 0;
                int totalMultiplyValue = 1;
                int totalCritChance = 10; //percent
                int totalCritMultiplier = 2;
                CalculateStats(modifier);
            }
        }

        public long ApplyAllModifiers(long moneyAmount)
        {
            long finalMoneyGained = CalculateCritReward(moneyAmount + totalAdditiveValue) * totalMultiplyValue;

            return finalMoneyGained;
        }

        private long CalculateCritReward(long moneyAmount)
        {
            bool superCritEnabled = totalCritChance > 100;
            int critChance = Math.Min(totalCritChance, 100);

            if (totalCritChance > 300)
            {
                int criticalLevel = totalCritChance / 100; // integer divde to always round down

                return (moneyAmount * (criticalLevel + (1 + totalCritMultiplier)));
            }

            if (superCritEnabled)
            {
                int superCritChance = totalCritChance - 100;
                int superCritRoll = generator.Next(1, 101);

                if (superCritRoll <= superCritChance)
                {
                    return (moneyAmount * totalCritMultiplier) * 2;
                }
                else
                {
                    return (moneyAmount * totalCritMultiplier);
                }
            }
            
            int normalCritRoll = generator.Next(1, 101);

            if (normalCritRoll <= critChance)
            {
                return (moneyAmount * totalCritMultiplier);
            }

            return moneyAmount;
        }

        //For testing
        public void SetCriticalChance(int inChance)
        {
            totalCritChance = inChance;
        }

        //Admin Command Only
        public void ClearAllModifiers()
        {
            modifierList.Clear();

            totalAdditiveValue = 0;
            totalMultiplyValue = 1;
            totalCritChance = 10; 
            totalCritMultiplier = 2;
        }

        public string GetModifierListAsString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var mod in modifierList)
            {
                builder.Append(mod);
            }
            return builder.ToString();
        }

        public List<Modifiers> GetModifierList()
        {
            return modifierList;
        }

    }
}
