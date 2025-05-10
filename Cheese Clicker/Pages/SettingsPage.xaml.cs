using Cheese_Clicker.SettingClasses;
using Cheese_Clicker.SoundClasses;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Cheese_Clicker.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        private double tempMusicLevel = 100;
        private double tempSoundLevel = 100;
        private double originalMusicLevel = GameSettings.MusicVolumeLevel;
        private double originalSoundLevel = GameSettings.SoundEffectVolumeLevel;
        public SettingsPage()
        {
            InitializeComponent();
            MusicVolumeSlider.Value = originalMusicLevel;
            SoundEffectVolumeSlider.Value = originalSoundLevel;

            if (GameSettings.DevModeIsActive)
            {
                Debug.WriteLine("Dev Mode is on");
                DevModeCheckBox.IsChecked = true; 
            }
        }

        private void MusicVolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tempMusicLevel = e.NewValue;
        }
        private void SoundEffectVolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tempSoundLevel = e.NewValue;
        }

        private void MusicVolumeSlider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GameSettings.MusicVolumeLevel = tempMusicLevel;
            Debug.WriteLine("Music Level: " + GameSettings.MusicVolumeLevel);
            SoundManager.PlaySound(SoundEffects.Click);
        }

        private void SoundVolumeSlider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GameSettings.SoundEffectVolumeLevel = tempSoundLevel;
            Debug.WriteLine("Sound Level: " + GameSettings.SoundEffectVolumeLevel);
            SoundManager.PlaySound(SoundEffects.Click);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlaySound(SoundEffects.Click);
            NavigationService.GoBack();
        }

        private void DevModeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GameSettings.DevModeIsActive = true;
            Debug.WriteLine("Dev Mode On");
        }

        private void DevModeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            GameSettings.DevModeIsActive = false;
            Debug.WriteLine("Dev Mode off");
        }
    }
}
