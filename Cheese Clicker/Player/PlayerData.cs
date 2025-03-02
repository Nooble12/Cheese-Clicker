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
        private int money = 0;
        private int clickCount = 0;
        private string playerName = "N/A";

        public PlayerData(int inMoney)
        {
            money = inMoney;
        }

        public void IncrementClickCount()
        {
            clickCount += 1;
        }

        public int GetClickCount()
        {
            return clickCount;
        }

        public void AddMoney(int amount)
        {
            money += amount;
        }

        public void RemoveMoney(int amount)
        {
            money -= amount;
        }

        public int GetMoney()
        {
            return money;
        }
    }
}
