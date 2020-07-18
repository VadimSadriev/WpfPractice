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
        where TParent : new()
    {
        /// <summary>
        /// Fired when value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, args) => { };

        /// <summary>
        /// Fired when value changes even if value is the same
        /// </summary>
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        /// <summary>
        /// A singleton instance of parent class
        /// </summary>
        public static TParent Instance { get; private set; } = new TParent();

        /// <summary>
        /// The actual Attached property
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached(
                "Value",
                typeof(TProperty),
                typeof(BaseAttachedProperty<TParent, TProperty>),
                new UIPropertyMetadata(
                    default(TProperty),
                    new PropertyChangedCallback(OnValuePropertyChanged),
                    new CoerceValueCallback(OnValuePropertyUpdated)
                    ));

        /// <summary>
        /// Callback event when value property has changed
        /// </summary>
        /// <param name="d">The UI element that has changed</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Call parent function
            (Instance as BaseAttachedProperty<TParent, TProperty>)?.OnValueChanged(d, e);

            // Call event listeners
            (Instance as BaseAttachedProperty<TParent, TProperty>)?.ValueChanged(d, e);
        }

        /// <summary>
        /// Callback event when property changed if value is still the same
        /// </summary>
        /// <param name="d">The UI element that has changed</param>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            // Call parent function
            (Instance as BaseAttachedProperty<TParent, TProperty>)?.OnValueUpdated(d, value);

            // Call event listeners
            (Instance as BaseAttachedProperty<TParent, TProperty>)?.ValueUpdated(d, value);

            return value;
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

        /// <summary>
        /// Method called when any attached property of this type is changed even if the value the same
        /// </summary>
        public virtual void OnValueUpdated(DependencyObject sender, object value)
        {

        }
    }
}
