using Cheese_Clicker;
using Cheese_Clicker.ModifierClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseClickerTests
{
    public class PlayerDataTest
    {
        [Fact]
        public void Add_Money()
        {
            long money = 100;
            PlayerData player = new PlayerData(money, 0);

            long moneyToBeAdded = 100;
            player.AddMoney(moneyToBeAdded);

            Assert.Equal(200, player.GetMoney());
        }

        [Fact]
        public void Remove_Money()
        {
            long money = 100;
            PlayerData player = new PlayerData(money, 0);

            long moneyToBeRemoved = 100;
            player.RemoveMoney(moneyToBeRemoved);

            Assert.Equal(0, player.GetMoney());
        }

        [Fact]
        public void Increment_Click_Count()
        {
            int clickCount = 0;
            PlayerData player = new PlayerData(0, clickCount);

            player.IncrementClickCount();

            Assert.Equal(1, player.GetClickCount());
        }

    }
}
