using System.Diagnostics;
using System.IO;
using System.Media;

namespace Cheese_Clicker.SoundClasses
{
    public static class SoundManager
    {
        private static readonly string SoundDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "Sounds");

        public static SoundPlayer soundEffect;
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
                soundEffect = new SoundPlayer(Path.Combine(SoundDirectory, fileName));
                soundEffect.Play();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }

    }
}
