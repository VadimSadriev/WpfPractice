using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;
using WpfPractice.Animation;
using WpfPractice.AttachedProperties.Base;

namespace WpfPractice.AttachedProperties
{
    /// <summary>
    /// Base class to run any animation method when a boolean is set to true
    /// and a reverse animation when set to false
    /// </summary>
    public abstract class AnimateBaseProperty<TParent> : BaseAttachedProperty<TParent, bool>
        where TParent : BaseAttachedProperty<TParent, bool>, new()
    {
        /// <summary>
        /// Flag if this property first time loaded
        /// </summary>
        public bool FirstLoad { get; set; } = true;

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // Get the framework element
            if (!(sender is FrameworkElement element))
                return;

            // Dont fire if the value doesnt change
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;

            // On first load
            if (FirstLoad)
            {
                // Create a single self-unhookable event
                // for the elements loaded event
                RoutedEventHandler onLoaded = null;

                onLoaded = (ss, ee) =>
                {
                    element.Loaded -= onLoaded;

                    DoAnimation(element, (bool)value);

                    // NO loger in first load
                    FirstLoad = false;
                };

                element.Loaded += onLoaded;
            }
            else
            {
                DoAnimation(element, (bool)value);
            }
        }

        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {

        }
    }

    /// <summary>
    /// Animates a framework element sliding it in from the left on show
    /// and sliding out to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }
}
