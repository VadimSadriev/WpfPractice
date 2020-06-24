using System.Windows;
using System.Windows.Controls;
using WpfPractice.AttachedProperties.Base;

namespace WpfPractice.AttachedProperties
{
    /// <summary>
    /// The monitor password attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;

            if (passwordBox == null)
                return;

            // Remove any previous events
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((bool)e.NewValue)
            {
                // set default property
                HasTextProperty.SetValue(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        /// <summary>
        /// Fired when password value changed
        /// </summary>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// The HasText attached property for <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        /// <summary>
        /// Sets has text property based on if caller has text
        /// </summary>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}
