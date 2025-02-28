﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;

namespace Cheese_Clicker
{
    class BounceElement
    {
        public BounceElement(Button inButton)
        {
            PlayAnimation(inButton);
        }

        private void PlayAnimation(Button inButton)
        {
            inButton.RenderTransformOrigin = new Point(0.5, 0.5);
            var scaleTransform = new ScaleTransform(1, 1);
            inButton.RenderTransform = scaleTransform;

            var scaleAnimationX = new DoubleAnimation(1, 1.5, TimeSpan.FromSeconds(0.1)) { AutoReverse = true, };
            var scaleAnimationY = new DoubleAnimation(1, 1.5, TimeSpan.FromSeconds(0.1)) { AutoReverse = true, };

            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimationX);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimationY);
        }
    }
}
