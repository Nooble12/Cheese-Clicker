using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
