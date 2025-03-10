using Cheese_Clicker.PlayerClasses;

namespace CheeseClickerTests
{
    public class PlayerDataTest
    {
        [Fact]
        public void Add_Money()
        {
            long money = 100;
            StatisitcsManager player = new StatisitcsManager(money, 0);

            long moneyToBeAdded = 100;
            player.AddMoney(moneyToBeAdded);

            Assert.Equal(200, player.money);
        }

        [Fact]
        public void Remove_Money()
        {
            long money = 100;
            StatisitcsManager player = new StatisitcsManager(money, 0);

            long moneyToBeRemoved = 100;
            player.RemoveMoney(moneyToBeRemoved);

            Assert.Equal(0, player.money);
        }

        [Fact]
        public void Increment_Click_Count()
        {
            int clickCount = 0;
            StatisitcsManager player = new StatisitcsManager(0, clickCount);

            player.IncrementClickCount();

            Assert.Equal(1, player.clickCount);
        }

    }
}
