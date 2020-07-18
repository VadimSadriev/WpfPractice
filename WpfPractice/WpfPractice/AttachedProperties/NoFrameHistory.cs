using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfPractice.AttachedProperties.Base;

namespace WpfPractice.AttachedProperties
{
    /// <summary>
    /// No frame history attached property for creating a <see cref="Frame"/> that never shows navigation bar
    /// and keeps navigation history empty
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = (sender as Frame);

            // hide navigation bar
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            // clear history on navigate
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
