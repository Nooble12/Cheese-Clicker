using Cheese_Clicker.Generators;
using Cheese_Clicker.Pages;
using Cheese_Clicker.PlayerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseClickerTests
{
    public class GenerateRewardTest
    {
        [Fact]
        public void GetReward()
        {
            Player gameState = new Player();
            GenerateReward reward = new GenerateReward(gameState);

            long moneyGained = reward.GetReward();

            Assert.True(moneyGained > 0);
        }

        [Fact]
        public void CheckForItemReward()
        {
            Player gameState = new Player();
            GenerateReward reward = new GenerateReward(gameState);

            reward.SetChanceToWin(100);

            long moneyGained = reward.GetReward();

            Assert.True(gameState.inventory.GetInventorySize() >= 1);
        }
    }
}
