using Cheese_Clicker.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_Clicker.Generators
{
    public class GenerateReward
    {
        private GameState playerGameState;
        private RandomMoneyGenerator randomMoneyGenerator = new RandomMoneyGenerator(1, 100);
        private Random generator = new Random();
        private int chanceToWinItem = 10; // percent
        public GenerateReward(GameState playerGameState)
        {
            this.playerGameState = playerGameState;
        }

        public void SetChanceToWin(int inPercent)
        {
            chanceToWinItem = inPercent;
        }

        private void CheckForItemReward()
        {
            int number = generator.Next(1, 100);
            if (number <= chanceToWinItem)
            {
                RandomItemGenerator generator = new RandomItemGenerator();
                playerGameState.playerInventory.AddItem(generator.GetRandomItem(), 1);
            }
        }

        public long GetReward()
        {
            CheckForItemReward();
            long finalMoneyGenerated = playerGameState.modifierManager.ApplyAllModifiers(randomMoneyGenerator.GetRandomMoney());
            return finalMoneyGenerated;
        }
    }
}
