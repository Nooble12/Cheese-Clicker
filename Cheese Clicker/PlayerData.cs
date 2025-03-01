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
        private Int32 money = 0;
        private Int32 clickCount = 0;

        public PlayerData(Int32 inMoney)
        {
            money = inMoney;
        }

        public void AddMoney(Int32 amount)
        {
            money += amount;
        }

        public void RemoveMoney(Int32 amount)
        {
            money -= amount;
        }

        public Int32 GetMoney()
        {
            return money;
        }
    }
}
