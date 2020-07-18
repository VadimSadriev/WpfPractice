using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfPractice.Pages;

namespace WpfPractice.Controls
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        public PageHost()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Current page to show in page host
        /// </summary>
        public BasePage CurrentPage
        {
            get => (BasePage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        /// <summary>
        /// Registers current page as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        /// <summary>
        /// Called when current page value has changed
        /// </summary>
        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var oldPageFrame = (d as PageHost).OldPage;
            var newPageFrame = (d as PageHost).NewPage;

            // Store current page content as old page
            var oldPageContent = newPageFrame.Content;

            // Remove current page from newPageFrame
            newPageFrame.Content = null;

            // Move previous page into the old page frame
            oldPageFrame.Content = oldPageContent;

            // Animate out previous page when the loaded event fires
            // right after the call due to moving frames
            if (oldPageContent is BasePage oldPage)
            {
                oldPage.ShouldAnimateOut = true;
            }

            // Set new page content
            newPageFrame.Content = e.NewValue;
        }
    }
}
