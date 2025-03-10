using Cheese_Clicker.PlayerClasses;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Cheese_Clicker.DataSaving
{
    public class PlayerDataSaver
    {
        public void SavePlayerData(Player gameState, string fileName)
        {

            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string saveFolderPath = Path.Combine(projectDirectory, "SaveFiles");

            if (!Directory.Exists(saveFolderPath))
            {
                Directory.CreateDirectory(saveFolderPath);
                Debug.WriteLine("Folder not found. Created new folder");
            }

            string filePath = Path.Combine(saveFolderPath, fileName + ".xml");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Player));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                gameState.inventory.PrepareForSerialization();
                xmlSerializer.Serialize(fileStream, gameState);
            }
        }

        public String GetSavePath()
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string saveFolder = Path.Combine(projectDirectory, "SaveFiles");
            return saveFolder;
        }
    }
}
