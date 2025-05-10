using System.Xml.Serialization;

namespace Cheese_Clicker.SettingClasses
{
    [XmlRoot("GameSettings")]
    public class SerializeSettingsHelper
    {
        [XmlElement("SoundEffectVolumeLevel")]
        public double SoundEffectVolumeLevel { get; set; } = GameSettings.SoundEffectVolumeLevel;
        [XmlElement("MusicVolumeLevel")]
        public double MusicVolumeLevel { get; set; } = GameSettings.MusicVolumeLevel;

        [XmlElement("DeveloperModeIsActive")]
        public bool DevModeIsActive { get; set; } = GameSettings.DevModeIsActive;
    }
}
