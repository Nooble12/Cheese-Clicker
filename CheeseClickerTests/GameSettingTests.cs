using Cheese_Clicker.SettingClasses;

namespace CheeseClickerTests
{
    public class GameSettingTests
    {
        [Fact]
        public void Saving_And_Loading_GameSettings()
        {
            double musicVolume = 55.586;
            double soundVolume = 62.335;
            bool devModeActive = true;

            GameSettings.MusicVolumeLevel = musicVolume;
            GameSettings.SoundEffectVolumeLevel = soundVolume;
            GameSettings.DevModeIsActive = devModeActive;

            SettingsSaver saver = new SettingsSaver();
            saver.SaveGameSettings();

            //Sanitize GameSetting values
            GameSettings.MusicVolumeLevel = 0;
            GameSettings.SoundEffectVolumeLevel = 0;
            GameSettings.DevModeIsActive = false;

            SettingsLoader loader = new SettingsLoader();
            loader.LoadGameSettings();

            Assert.Equal(55.586, GameSettings.MusicVolumeLevel);
            Assert.Equal(62.335, GameSettings.SoundEffectVolumeLevel);
            Assert.True(GameSettings.DevModeIsActive);
        }
    }
}
