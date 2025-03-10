using Cheese_Clicker.ModifierClasses;

namespace Cheese_Clicker.Generators
{
    public class Reward
    {
        public long moneyGained { get; set; }
        public CriticalType criticalType { get; set; }
        public Reward(long inMoney, CriticalType inType)
        {
            moneyGained = inMoney;
            criticalType = inType;
        }

    }
}
