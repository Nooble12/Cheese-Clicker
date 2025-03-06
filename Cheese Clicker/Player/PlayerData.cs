using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cheese_Clicker
{
    public class PlayerData
    {
        private long money = 0;
        private int clickCount = 0;
        private string playerName = "N/A";

        public PlayerData(long inMoney, int inClickCount)
        {
            money = inMoney;
            clickCount = inClickCount;
        }

        public void IncrementClickCount()
        {
            clickCount += 1;
        }

        public int GetClickCount()
        {
            return clickCount;
        }

        public void AddMoney(long amount)
        {
            money += amount;
        }

        public void RemoveMoney(long amount)
        {
            money -= amount;
        }

        public long GetMoney()
        {
            return money;
        }
    }
}
