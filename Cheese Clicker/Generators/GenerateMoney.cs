using Cheese_Clicker.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_Clicker.Generators
{
    public class GenerateMoney
    {
        private GameState playerGameState;
        private RandomMoneyGenerator randomMoneyGenerator = new RandomMoneyGenerator(1, 100);
        public GenerateMoney(GameState playerGameState)
        {
            this.playerGameState = playerGameState;
        }

        public long GetFinalMoneyGenerated()
        {
            long finalMoneyGenerated = playerGameState.modifierManager.ApplyAllModifiers(randomMoneyGenerator.GetRandomMoney());
            return finalMoneyGenerated;
        }
    }
}
