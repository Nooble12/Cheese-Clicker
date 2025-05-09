using Cheese_Clicker.Items;
using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.PlayerClasses;

namespace CheeseClickerTests
{
    public class MasteryRankTests
    {
        [Fact]
        public void Rank_Up_Mastery_Rank()
        {
            //public Player(StatisitcsManager inStatsManager, ModifierManager inModifiers, Inventory inInventory)
            StatisticsManager statsManager = new StatisticsManager();
            ModifierManager modManager = new ModifierManager();
            Inventory inventory = new Inventory();
            Player testPlayer = new Player(statsManager, modManager, inventory);

            //Add Items to inventory to test for item deletion
            testPlayer.inventory.AddItem(new ComputerItem(), 15);
            testPlayer.inventory.AddItem(new CheeseItem(), 22);

            //Add money to stats to test for money reest
            testPlayer.statistics.AddMoney(1999);

            //Add item modifiers to test for item modifier reset
            testPlayer.modifierManager.AddModifier(new ComputerItemModifier());
            testPlayer.modifierManager.AddModifier(new CheeseItemModifier());

            //Create MasteryRankManager Object
            MasteryRankManager masteryRankManager = new MasteryRankManager(testPlayer);
            masteryRankManager.RankUpMastery();

            Assert.Equal(0, testPlayer.inventory.GetInventorySize());
            Assert.Equal(0, testPlayer.statistics.money);
            // Should only have 1 perma mod from mastery rank up.
            Assert.Single(testPlayer.modifierManager.GetModifierList());
        }

        [Fact]
        public void Check_Mastery_Rank_Eligibility()
        {
            StatisticsManager statsManager = new StatisticsManager();
            ModifierManager modManager = new ModifierManager();
            Inventory inventory = new Inventory();
            Player testPlayer = new Player(statsManager, modManager, inventory);

            //Set player money
            testPlayer.statistics.money = 1000000;

            MasteryRankManager masteryRankManager = new MasteryRankManager(testPlayer);
            bool canRankUp = masteryRankManager.CheckMasteryRankEligibility();

            Assert.True(canRankUp);

            //Set player money
            testPlayer.statistics.money = 0;
            canRankUp = masteryRankManager.CheckMasteryRankEligibility();
            Assert.False(canRankUp);
        }

        [Fact]
        public void Get_Mastery_Rank_Eligibility_Requirement()
        {
            StatisticsManager statsManager = new StatisticsManager();
            ModifierManager modManager = new ModifierManager();
            Inventory inventory = new Inventory();
            Player testPlayer = new Player(statsManager, modManager, inventory);

            //Set player mastery rank
            testPlayer.statistics.masteryRankLevel = 0;

            MasteryRankManager masteryRankManager = new MasteryRankManager(testPlayer);

            List<long> actualResultsList = new List<long>();

            for (int i = 0; i < 10; i++)
            {
                long rankUpCost = masteryRankManager.GetMasteryRankEligibilityRequirement();
                actualResultsList.Add(rankUpCost);
                testPlayer.statistics.IncrementMasteryRankLevel();
            }

            //Manual calculated values for the function: f\left(x\right)\ =\ b^{\frac{x}{10}}\cdot c
            List<long> expectedResultsList = new List<long>
            {
                1000000,
                1258925,
                1584893,
                1995262,
                2511886,
                3162277,
                3981071,
                5011872,
                6309573,
                7943282,
            };

            Assert.Equal(expectedResultsList, actualResultsList);
        }
    }
}
