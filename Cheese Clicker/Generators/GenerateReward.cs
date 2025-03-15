using Cheese_Clicker.PlayerClasses;

namespace Cheese_Clicker.Generators
{
    public class GenerateReward
    {
        private Player player;
        private RandomMoneyGenerator randomMoneyGenerator = new RandomMoneyGenerator(1, 100);
        private Random generator = new Random();
        private int chanceToWinItem = 10; // percent
        public GenerateReward(Player playerGameState)
        {
            this.player = playerGameState;
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
                player.inventory.AddItem(generator.GetRandomItem(), 1);
            }
        }

        public Reward GetReward()
        {
            CheckForItemReward();
            Reward reward = player.modifierManager.ApplyAllModifiers(randomMoneyGenerator.GetRandomMoney());
            return reward;
        }

        public Reward GetSellItemReward(long inValue)
        {
            Reward reward = player.modifierManager.ApplyAllModifiers(inValue);
            return reward;
        }
    }
}
