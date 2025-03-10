using Cheese_Clicker.PlayerClasses;
using System.IO;
using System.Xml.Serialization;

namespace Cheese_Clicker.DataSaving
{
    public class PlayerDataLoader
    {
        public Player LoadPlayerGameState (string inFileName)
        {

            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string saveFolderPath = Path.Combine(projectDirectory, "SaveFiles");
            string saveFilePath = Path.Combine(saveFolderPath, inFileName);

            Player gameState;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Player));
            using (FileStream fileStream = new FileStream(saveFilePath, FileMode.Open))
            {
                gameState = (Player)xmlSerializer.Deserialize(fileStream);
                gameState.inventory.PrepareAfterDeserialization();
            }
            gameState.modifierManager.ReCalculateAllStats();
            return gameState;
        }
    }
}
