using Cheese_Clicker.DataSaving;
using Cheese_Clicker.ModifierClasses;
using Cheese_Clicker.PlayerClasses;
using Cheese_Clicker.SettingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseClickerTests
{
    public class GameSettingTests
    {
        [Fact]
        public void Saving_And_Loading_GameSettings()
        {
            double musicVolume = 55.586;
            double soundVolume = 62.335;

            GameSettings.MusicVolumeLevel = musicVolume;
            GameSettings.SoundEffectVolumeLevel = soundVolume;

            SettingsSaver saver = new SettingsSaver();
            saver.SaveGameSettings();

            //Sanitize GameSetting values
            GameSettings.MusicVolumeLevel = 0;
            GameSettings.SoundEffectVolumeLevel = 0;

            SettingsLoader loader = new SettingsLoader();
            loader.LoadGameSettings();

            Assert.Equal(55.586, GameSettings.MusicVolumeLevel);
            Assert.Equal(62.335, GameSettings.SoundEffectVolumeLevel);
        }
    }
}
