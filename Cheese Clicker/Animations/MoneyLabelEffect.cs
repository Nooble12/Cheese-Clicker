using Cheese_Clicker.Generators;
using Cheese_Clicker.ModifierClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

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

        private Label SpawnLabel(Reward inReward)
        {
            Label moneyLabel = new Label
            {
                Content = $"+ ${inReward.moneyGained:N0}",
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(50, 50, 0, 0),
            };

            switch (inReward.criticalType)
            {
                case CriticalType.Normal:
                    moneyLabel.Foreground = new SolidColorBrush(Colors.Black);
                    break;

                case CriticalType.Critical:
                    moneyLabel.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;

                case CriticalType.SuperCritical:
                    moneyLabel.Foreground = new SolidColorBrush(Colors.Red);
                    break;
            }

            (currentPage.Content as Panel)?.Children.Add(moneyLabel);

            moneyLabel.IsHitTestVisible = false;

            return moneyLabel;
        }
        public void PlayAnimation(Reward inReward)
        {
            Label moneyLabel = SpawnLabel(inReward);

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
