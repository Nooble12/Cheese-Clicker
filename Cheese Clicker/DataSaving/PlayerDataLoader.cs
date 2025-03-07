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
        public PlayerData LoadPlayerData(string inFilePath)
        {
            PlayerData playerData;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayerData));
            using (FileStream fileStream = new FileStream(inFilePath, FileMode.Open))
            {
                playerData = (PlayerData)xmlSerializer.Deserialize(fileStream);
            }

            return playerData;
        }
    }
}
