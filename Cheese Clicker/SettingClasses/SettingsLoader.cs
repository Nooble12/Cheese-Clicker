using Cheese_Clicker.PlayerClasses;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Cheese_Clicker.SettingClasses
{
    public class SettingsLoader
    {
        public void LoadGameSettings()
        {
            try
            {
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string saveFolderPath = Path.Combine(projectDirectory, "SaveFiles");
                string saveFilePath = Path.Combine(saveFolderPath, "GameSettings.xml");

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerializeSettingsHelper));
                SerializeSettingsHelper settings = new SerializeSettingsHelper();
                using (FileStream fileStream = new FileStream(saveFilePath, FileMode.Open))
                {
                    settings = (SerializeSettingsHelper)xmlSerializer.Deserialize(fileStream);
                }

                ApplySettings(settings);

            }catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private void ApplySettings(SerializeSettingsHelper inSettings)
        {
            GameSettings.MusicVolumeLevel = inSettings.MusicVolumeLevel;
            GameSettings.SoundEffectVolumeLevel = inSettings.SoundEffectVolumeLevel;
            GameSettings.DevModeIsActive = inSettings.DevModeIsActive;
        }
    }
}
