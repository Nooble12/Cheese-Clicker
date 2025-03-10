using Cheese_Clicker;
using Cheese_Clicker.DataSaving;
using Cheese_Clicker.Items;
using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.PlayerClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseClickerTests
{
    public class PlayerDataSaverAndLoaderTest
    {

        [Fact]
        public void Saving_And_Loading_PlayerData()
        {
            long money = 200;
            int clicks = 10;
            StatisitcsManager player = new StatisitcsManager(money, 10);
            ModifierManager manager = new ModifierManager();
            Inventory inventory = new Inventory();
            Player gameState = new Player(player, manager, inventory);

            PlayerDataSaver dataSaver = new();
            dataSaver.SavePlayerData(gameState, "TestFile");

            PlayerDataLoader dataLoader = new PlayerDataLoader();
         
            Player testState = new Player();
            testState = dataLoader.LoadPlayerGameState("TestFile.xml");

            Assert.Equal(200, testState.statistics.money);
            Assert.Equal(10, testState.statistics.clickCount);
        }

        [Fact]
        public void Saving_And_Loading_ModifierManager()
        {
            StatisitcsManager player = new StatisitcsManager();
            ModifierManager manager = new ModifierManager();
            Inventory inventory = new Inventory();
            Player gameState = new Player(player, manager, inventory);

            //Add mods
            Modifiers addMod = new AdditiveModifier();
            Modifiers multiplyMod = new MultiplierModifier();
            Modifiers criticalChanceMod = new CriticalChanceModifier();
            Modifiers criticalMultiplyMod = new CriticalMultiplierModifier();
            gameState.modifierManager.AddModifier(addMod);
            gameState.modifierManager.AddModifier(multiplyMod);
            gameState.modifierManager.AddModifier(criticalChanceMod);
            gameState.modifierManager.AddModifier(criticalMultiplyMod);

            PlayerDataSaver dataSaver = new();
            dataSaver.SavePlayerData(gameState, "TestModifiersFile");

            PlayerDataLoader dataLoader = new PlayerDataLoader();
            Player testState = new Player();
            testState = dataLoader.LoadPlayerGameState("TestModifiersFile.xml");

            ModifierManager testManager = new ModifierManager();
            testManager.AddModifier(addMod);
            testManager.AddModifier(multiplyMod);
            testManager.AddModifier(criticalChanceMod);
            testManager.AddModifier(criticalMultiplyMod);

            List<Modifiers> actualList = testState.modifierManager.GetModifierList();
            List <Modifiers> expectedList = testManager.GetModifierList();

            String expectedMod = expectedList[2].ToString().Trim();
            String actualMod = actualList[2].ToString().Trim();

            Assert.Equal(expectedMod, actualMod);
        }

        [Fact]
        public void Saving_And_Loading_PlayerInventory()
        {
            StatisitcsManager player = new StatisitcsManager();
            ModifierManager manager = new ModifierManager();
            Inventory inventory = new Inventory();
            Player gameState = new Player(player, manager, inventory);

            Item computerItem = new ComputerItem();
            Item cheeseItem = new CheeseItem();

            inventory.AddItem(computerItem, 1);
            inventory.AddItem(computerItem, 1);
            inventory.AddItem(cheeseItem, 1);

            PlayerDataSaver dataSaver = new();
            dataSaver.SavePlayerData(gameState, "TestInventoryFile");

            PlayerDataLoader dataLoader = new PlayerDataLoader();
            Player testState = new Player();
            testState = dataLoader.LoadPlayerGameState("TestInventoryFile.xml");

            int actualComputerCount = testState.inventory.GetItemQuantity(computerItem);
            int actualCheeseCount = testState.inventory.GetItemQuantity(cheeseItem);

            Assert.Equal(2, actualComputerCount);
            Assert.Equal(1, actualCheeseCount);
        }
    }
}
