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
        public void SavePlayerData(PlayerData inPlayerData, string saveFolderPath, string fileName)
        {
            if (!Directory.Exists(saveFolderPath))
            {
                Directory.CreateDirectory(saveFolderPath);
                Debug.WriteLine("Folder not found. Created new folder");
            }

            string filePath = Path.Combine(saveFolderPath, fileName + ".xml");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayerData));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, inPlayerData);
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
