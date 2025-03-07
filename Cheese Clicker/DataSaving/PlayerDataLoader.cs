using Cheese_Clicker.Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cheese_Clicker.DataSaving
{
    public class PlayerDataLoader
    {
        public GameState LoadPlayerGameState (string inFileName)
        {

            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string saveFolderPath = Path.Combine(projectDirectory, "SaveFiles");
            string saveFilePath = Path.Combine(saveFolderPath, inFileName);

            GameState gameState;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameState));
            using (FileStream fileStream = new FileStream(saveFilePath, FileMode.Open))
            {
                gameState = (GameState)xmlSerializer.Deserialize(fileStream);
            }
            gameState.modifierManager.ReCalculateAllStats();
            return gameState;
        }
    }
}
