using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_Clicker
{
    class PlayerData
    {
        private static Int32 money = 0;
        private static Int32 clickCount = 0;

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
