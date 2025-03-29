using System.Diagnostics;
using System.IO;
using System.Media;
using System.Windows.Media;

namespace Cheese_Clicker.SoundClasses
{
    public static class SoundManager
    {
        private static readonly string SoundDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "Sounds");

        public static MediaPlayer soundEffect;
        public static void PlaySound(SoundEffects sound)
        {
            switch (sound)
            {
                case SoundEffects.Click:
                    LoadAndPlaySound("Click.wav");
                break;

                case SoundEffects.Sell:
                    
                break;

                case SoundEffects.Highlight:

                break;
            }
        }

        private static void LoadAndPlaySound(string fileName)
        {
            try 
            {
                soundEffect = new MediaPlayer();
                soundEffect.Open(new Uri(Path.Combine(SoundDirectory, fileName)));
                soundEffect.Play();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }

    }
}
