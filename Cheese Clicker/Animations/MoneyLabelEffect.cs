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

        private Random generator = new Random();
        public MoneyLabelEffect(Page inPage)
        {
            currentPage = inPage;
        }

        private Label SpawnLabel(long inMoney)
        {
            Label moneyLabel = new Label
            {
                Content = $"+ ${inMoney:N0}",
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(50, 50, 0, 0)
            };
            (currentPage.Content as Panel)?.Children.Add(moneyLabel);

            moneyLabel.IsHitTestVisible = false;

            return moneyLabel;
        }
        public void PlayAnimation(long inMoney)
        {
            Label moneyLabel = SpawnLabel(inMoney);

            TranslateTransform moveTransform = new TranslateTransform();
            moneyLabel.RenderTransform = moveTransform;

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
                if (moneyLabel.Parent is Panel parentPanel)
                {
                    parentPanel.Children.Remove(moneyLabel);
                }
            };

            moveTransform.BeginAnimation(TranslateTransform.XProperty, animX);
            moveTransform.BeginAnimation(TranslateTransform.YProperty, animY);

        }
    }
}
