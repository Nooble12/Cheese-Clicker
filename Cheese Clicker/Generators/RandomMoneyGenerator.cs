namespace Cheese_Clicker.Generators
{
    class RandomMoneyGenerator
    {

        private int minVal;
        private int maxVal;

        public RandomMoneyGenerator(int inMinVal, int inMaxVal)
        {
            minVal = inMinVal;
            maxVal = inMaxVal;
        }
        public int GetRandomMoney()
        {
            Random generator = new Random();

            return generator.Next(minVal, maxVal);
        }
    }
}
