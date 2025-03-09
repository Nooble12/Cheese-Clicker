using Cheese_Clicker.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cheese_Clicker.DataSaving
{
    public class PlayerDataSaver
    {
        public void SavePlayerData(GameState gameState, string fileName)
        {

            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string saveFolderPath = Path.Combine(projectDirectory, "SaveFiles");

            if (!Directory.Exists(saveFolderPath))
            {
                Directory.CreateDirectory(saveFolderPath);
                Debug.WriteLine("Folder not found. Created new folder");
            }

            string filePath = Path.Combine(saveFolderPath, fileName + ".xml");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameState));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                gameState.playerInventory.PrepareForSerialization();
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
