using Cheese_Clicker.Generators;
using System.Diagnostics;
using System.Printing;
using System.Text;
using System.Xml.Serialization;

namespace Cheese_Clicker.ModifierClasses
{
    [XmlRoot("ModifierManager")]
    public class ModifierManager
    {
        [XmlElement("ModifierList")]
        public List<Modifiers> modifierList = new List<Modifiers>();

        private Random generator = new Random();

        //Modifier Values
        private int totalAdditiveValue = 0;
        private int totalMultiplyValue = 1;
        private int totalCritChance = 10; //percent
        private int totalCritMultiplier = 2;

        //Item Modifier Buffs
        private int totalItemMultiplierValue = 1;

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
                case CheeseItemModifier multiplyMod:
                    totalItemMultiplierValue += inModifier.GetModifierValue();
                    break;
                case ComputerItemModifier multiplyMod:
                    totalItemMultiplierValue += inModifier.GetModifierValue();
                    break;
            }
        }

        //Only runs on game start up
        public void ReCalculateAllStats()
        {
            foreach (var modifier in modifierList)
            {
                CalculateStats(modifier);
            }
        }

        CriticalType critType = CriticalType.Normal;

        public Reward ApplyAllModifiers(long moneyAmount)
        {
            long finalMoneyGained = CalculateCritReward(moneyAmount + totalAdditiveValue) * totalMultiplyValue * totalItemMultiplierValue;

            Reward rewardObject = new Reward(finalMoneyGained, critType);

            return rewardObject;
        }

        private long CalculateCritReward(long moneyAmount)
        {
            bool superCritEnabled = totalCritChance > 100;
            int critChance = Math.Min(totalCritChance, 100);

            critType = CriticalType.Normal;

            if (totalCritChance > 300)
            {
                int criticalLevel = totalCritChance / 100; // integer divde to always round down

                critType = CriticalType.SuperCritical;

                return (moneyAmount * (criticalLevel + (1 + totalCritMultiplier)));
            }

            if (superCritEnabled)
            {
                int superCritChance = totalCritChance - 100;
                int superCritRoll = generator.Next(1, 101);

                if (superCritRoll <= superCritChance)
                {
                    critType = CriticalType.SuperCritical;
                    return (moneyAmount * totalCritMultiplier) * 2;
                }
                else
                {
                    critType = CriticalType.Critical;
                    return (moneyAmount * totalCritMultiplier);
                }
            }
            
            int normalCritRoll = generator.Next(1, 101);

            if (normalCritRoll <= critChance)
            {
                critType = CriticalType.Critical;
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

        public void ResetAllItemModifiers()
        {
            totalItemMultiplierValue = 1;

            modifierList.RemoveAll(mod => mod is ItemModifiers);
        }

    }
}
