using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Cheese_Clicker
{
    public class BounceElement
    {
        public void PlayAnimation(Button inButton, double maxSizeIncrease, double duration)
        {
            inButton.RenderTransformOrigin = new Point(0.5, 0.5);
            var scaleTransform = new ScaleTransform(1, 1);
            inButton.RenderTransform = scaleTransform;

            var scaleAnimationX = new DoubleAnimation(1, maxSizeIncrease, TimeSpan.FromSeconds(duration)) { AutoReverse = true, };
            var scaleAnimationY = new DoubleAnimation(1, maxSizeIncrease, TimeSpan.FromSeconds(duration)) { AutoReverse = true, };
            scaleAnimationX.EasingFunction = new SineEase();
            scaleAnimationY.EasingFunction = new SineEase();

            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimationX);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimationY);
        }
    }
}
