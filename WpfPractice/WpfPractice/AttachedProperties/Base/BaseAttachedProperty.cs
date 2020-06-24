using System;
using System.Windows;

namespace WpfPractice.AttachedProperties.Base
{
    /// <summary>
    /// Base attached property
    /// </summary>
    /// <typeparam name="TParent">Parent class to be the attached property</typeparam>
    /// <typeparam name="TProperty">Type of this attached property</typeparam>
    public abstract class BaseAttachedProperty<TParent, TProperty>
        where TParent : BaseAttachedProperty<TParent, TProperty>, new()
    {
        /// <summary>
        /// Fired when value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, args) => { };

        /// <summary>
        /// A singleton instance of parent class
        /// </summary>
        public static TParent Instance { get; private set; } = new TParent();

        /// <summary>
        /// The actual Attached property
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(TProperty), typeof(BaseAttachedProperty<TParent, TProperty>), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// Callback event when value property has changed
        /// </summary>
        /// <param name="d">The UI element that has changed</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Call parent function
            Instance.OnValueChanged(d, e);

            // Call event listeners
            Instance.ValueChanged(d, e);
        }

        /// <summary>
        /// Gets the attached property
        /// </summary>
        public static TProperty GetValue(DependencyObject d)
        {
            return (TProperty)d.GetValue(ValueProperty);
        }

        /// <summary>
        /// Sets the attached property
        /// </summary>
        public static void SetValue(DependencyObject d, TProperty value)
        {
            d.SetValue(ValueProperty, value);
        }

        /// <summary>
        /// Method called when any attached property of this type is changed
        /// </summary>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
