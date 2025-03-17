namespace Cheese_Clicker.Generators
{
    public class RandomOutcome
    {
        Random generator = new Random();
        private int chanceToWin = 0;
        public RandomOutcome(int inChanceToWin)
        {
            chanceToWin = inChanceToWin;
        }

        public bool GetOutcome()
        {
            int randomNumber = generator.Next(1, 100);
            if (randomNumber <= chanceToWin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
