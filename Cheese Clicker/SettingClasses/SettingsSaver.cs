using Cheese_Clicker.PlayerClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cheese_Clicker.SettingClasses
{
    public class SettingsSaver
    {
        public void SaveGameSettings()
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string saveFolderPath = Path.Combine(projectDirectory, "SaveFiles");

            if (!Directory.Exists(saveFolderPath))
            {
                Directory.CreateDirectory(saveFolderPath);
                Debug.WriteLine("Folder not found. Created new folder");
            }

            string filePath = Path.Combine(saveFolderPath, "GameSettings.xml");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerializeSettingsHelper));
            SerializeSettingsHelper settings = new SerializeSettingsHelper();

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, settings);
            }
        }
    }
}
