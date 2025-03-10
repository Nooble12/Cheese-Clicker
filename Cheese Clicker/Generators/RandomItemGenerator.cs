using Cheese_Clicker.Items;

namespace Cheese_Clicker.Generators
{
    public class RandomItemGenerator
    {
        private Random generator = new Random();
        private List<Item> itemList = new List<Item>();

        public RandomItemGenerator()
        {
            itemList.Add(new CheeseItem());
            itemList.Add(new ComputerItem());
        }
        public Item GetRandomItem()
        {
            int selectedItem = generator.Next(0, itemList.Count);
            return itemList[selectedItem];
        }
    }
}
