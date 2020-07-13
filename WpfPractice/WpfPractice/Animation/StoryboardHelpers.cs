using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace WpfPractice.Animation
{
    /// <summary>
    /// Animation helpers for storyboards
    /// </summary>
    public static class StoryboardHelpers
    {
        /// <summary>
        /// Adds the slide and fade in animation to the story board
        /// </summary>
        public static void AddSlideFromRight(this Storyboard sb, float second, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(second)),
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide from left animation to the storyboard
        /// </summary>
        public static void AddSlideFromLeft(this Storyboard sb, float second, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(second)),
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide to right animation to the story board
        /// </summary>
        public static void AddSlideToRight(this Storyboard sb, float second, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(second)),
                From = new Thickness(0),
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide to left animation
        /// </summary>
        public static void AddSlideToLeft(this Storyboard sb, float second, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(second)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Add fade in animation to storyboard
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="second"></param>
        public static void AddFadeIn(this Storyboard sb, float second)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(second)),
                From = 0,
                To = 1,
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            sb.Children.Add(animation);
        }


        /// <summary>
        /// Add fade out animation to storyboard
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="second"></param>
        public static void AddFadeOut(this Storyboard sb, float second)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(second)),
                From = 1,
                To = 0,
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            sb.Children.Add(animation);
        }
    }
}
