using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightApplication1
{
    public partial class FallingSquares : UserControl
    {
        public FallingSquares()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Generate some rectangles.
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                // Create a new rectangle.
                Rectangle rect = new Rectangle();
                rect.Fill = new SolidColorBrush(Colors.Red);

                // Size and place it randomly.
                rect.Width = rand.Next(10, 40);
                rect.Height = rand.Next(10, 40);
                Canvas.SetTop(rect, rand.Next((int)(this.Height - rect.Height)));
                Canvas.SetLeft(rect, rand.Next((int)(this.Width - rect.Width)));

                // Handle clicks.
                rect.MouseLeftButtonDown += rect_MouseLeftButtonDown;

                // Add it to the Canvas.
                canvas.Children.Add(rect);
            }
        }

        private Dictionary<Storyboard, Rectangle> animatedShapes = new Dictionary<Storyboard, Rectangle>();

        private void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            
            // Create the storyboard for the rectangle.
            Storyboard storyboard = new Storyboard();            

            // Create the animation for moving the rectangle.
            DoubleAnimation fallingAnimation = new DoubleAnimation();
            Storyboard.SetTarget(fallingAnimation, rect);
            Storyboard.SetTargetProperty(fallingAnimation, new PropertyPath("(Canvas.Top)"));            
            fallingAnimation.To = this.Height - rect.Height;
            fallingAnimation.Duration = TimeSpan.FromSeconds(2);
            storyboard.Children.Add(fallingAnimation);

            // Create the animation for changing the rectangle's color.
            ColorAnimation colorAnimation = new ColorAnimation();
            Storyboard.SetTarget(colorAnimation, rect.Fill);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("Color"));
            colorAnimation.To = Colors.Green;
            colorAnimation.Duration = fallingAnimation.Duration;
            storyboard.Children.Add(colorAnimation);

            // Track the rectangle.
            animatedShapes.Add(storyboard, rect);

            // React when the storyboard is finished.
            storyboard.Completed += storyboard_Completed;

            // Start the storyboard.
            storyboard.Begin();            
        }

        private void storyboard_Completed(object sender, EventArgs e)
        {
            // Stop the animation.
            //Storyboard storyboard = (Storyboard)sender;
            //storyboard.Stop();
        
            // Or, stop the animation but keep the new position.
            Storyboard storyboard = (Storyboard)sender;            
            Rectangle rect = animatedShapes[storyboard];
            double newTop = Canvas.GetTop(rect);
            storyboard.Stop();
            Canvas.SetTop(rect, newTop);
            ((SolidColorBrush)rect.Fill).Color = Colors.LightGray;
            
            animatedShapes.Remove(storyboard);            
        }
    }
}
