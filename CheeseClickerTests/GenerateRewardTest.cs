using Cheese_Clicker.Generators;
using Cheese_Clicker.Pages;
using Cheese_Clicker.Player;
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
            GameState gameState = new GameState();
            GenerateReward reward = new GenerateReward(gameState);

            long moneyGained = reward.GetReward();

            Assert.True(moneyGained > 0);
        }

        [Fact]
        public void CheckForItemReward()
        {
            GameState gameState = new GameState();
            GenerateReward reward = new GenerateReward(gameState);

            reward.SetChanceToWin(100);

            long moneyGained = reward.GetReward();

            Assert.True(gameState.playerInventory.GetInventorySize() >= 1);
        }
    }
}
