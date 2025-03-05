using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Diagnostics;

namespace Cheese_Clicker.Animations
{
    public class MoneyLabelEffect
    {
        private Page currentPage;
        private Button currentButton;
        private int moneyAmount;

        private Random generator = new Random();
        public MoneyLabelEffect(Page inPage, Button inButton, int inMoneyAmount)
        {
            currentButton = inButton;
            currentPage = inPage;
            moneyAmount = inMoneyAmount;
            SpawnLabel();
        }

        private void SpawnLabel()
        {
            Label moneyLabel = new Label
            {
                Content = "+ $" + moneyAmount,
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(50, 50, 0, 0)
            };
            (currentPage.Content as Panel)?.Children.Add(moneyLabel);

            moneyLabel.IsHitTestVisible = false;

            PlayAnimation(moneyLabel);
        }
        private void PlayAnimation(Label inLabel)
        {
            TranslateTransform moveTransform = new TranslateTransform();
            inLabel.RenderTransform = moveTransform;

            PathGeometry path = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = new Point(0, 0); // should be center of page

            int xMax = generator.Next(-300, 300);
            int yMax = generator.Next(-300, 0);

            QuadraticBezierSegment bezier = new QuadraticBezierSegment
            {
                Point1 = new Point(xMax, yMax),  // Peak of the parabola
                Point2 = new Point(xMax, 400)  // End point
            };

            figure.Segments.Add(bezier);
            path.Figures.Add(figure);

            DoubleAnimationUsingPath animX = new DoubleAnimationUsingPath
            {
                PathGeometry = path,
                Source = PathAnimationSource.X,
                Duration = TimeSpan.FromSeconds(1)
            };

            DoubleAnimationUsingPath animY = new DoubleAnimationUsingPath
            {
                PathGeometry = path,
                Source = PathAnimationSource.Y,
                Duration = TimeSpan.FromSeconds(1)
            };

            animY.Completed += (sender, e) =>
            {
                if (inLabel.Parent is Panel parentPanel)
                {
                    parentPanel.Children.Remove(inLabel);
                }
            };

            moveTransform.BeginAnimation(TranslateTransform.XProperty, animX);
            moveTransform.BeginAnimation(TranslateTransform.YProperty, animY);

        }
    }
}
