using Cheese_Clicker;
using Cheese_Clicker.DataSaving;
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
        public void Saving_And_Loading()
        {
            long money = 200;
            int clicks = 10;
            PlayerData player = new PlayerData(money, 10);

            string saveFileName = "TestFile";

            string testSaveFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestSaveFolder");

            Debug.WriteLine(testSaveFolderPath);

            PlayerDataSaver dataSaver = new();
            dataSaver.SavePlayerData(player, testSaveFolderPath, saveFileName);

            PlayerDataLoader dataLoader = new PlayerDataLoader();
            string filePath = Path.Combine(testSaveFolderPath, saveFileName + ".xml");

            PlayerData newPlayer = new PlayerData(0, 0);
            newPlayer = dataLoader.LoadPlayerData(filePath);

            Assert.Equal(200, newPlayer.money);
            Assert.Equal(10, newPlayer.clickCount);
        }
    }
}
