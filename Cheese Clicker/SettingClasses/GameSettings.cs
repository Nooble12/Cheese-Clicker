using System.Xml.Serialization;

namespace Cheese_Clicker.SettingClasses
{
    public static class GameSettings
    {
        public static double SoundEffectVolumeLevel { get; set; }
        public static double MusicVolumeLevel { get; set; } 
        public static bool DevModeIsActive { get; set; }
    }
}
