using Cheese_Clicker.DefaultConfig;
using Cheese_Clicker.PlayerClasses;

namespace CheeseClickerTests
{
    public class DefaultGameStatsLoaderTest
    {
        [Fact]
        public void Deserialize_Json_File()
        {
            //Loads default values from DefaultGameConfig.json
            DefaultGameStatsLoader loader = new DefaultGameStatsLoader("DefaultGameConfigTest.json");
            DefaultStats stats = loader.GetDefaultStats();
            StatisticsManager statisitcsManager = new StatisticsManager(stats.startingMoney, stats.clickCount, stats.defaultMasteryRank, stats.totalMoneyGained);

            Assert.Equal(1, statisitcsManager.masteryRankLevel);
            Assert.Equal(2, statisitcsManager.money);
            Assert.Equal(3, statisitcsManager.clickCount);
            Assert.Equal(4, statisitcsManager.totalMoneyGained);
        }
    }
}
