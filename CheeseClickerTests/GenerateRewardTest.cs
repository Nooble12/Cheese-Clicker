using Cheese_Clicker.Generators;
using Cheese_Clicker.PlayerClasses;

namespace CheeseClickerTests
{
    public class GenerateRewardTest
    {
        [Fact]
        public void GetReward()
        {
            Player gameState = new Player();
            GenerateReward reward = new GenerateReward(gameState);

            Reward returnedReward = reward.GetReward();
            long moneyGained = returnedReward.moneyGained;

            Assert.True(moneyGained > 0);
        }

        [Fact]
        public void CheckForItemReward()
        {
            Player gameState = new Player();
            GenerateReward reward = new GenerateReward(gameState);

            reward.SetChanceToWin(100);

            Reward returnedReward = reward.GetReward();
            long moneyGained = returnedReward.moneyGained;

            Assert.True(gameState.inventory.GetInventorySize() >= 1);
        }
    }
}
