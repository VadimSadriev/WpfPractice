using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfPractice.Animation;
using WpfPractice.Core.ViewModels.Base;

namespace WpfPractice.Pages
{
    /// <summary>
    /// Base pages for all pages
    /// </summary>
    public class BasePage : Page
    {
        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            this.Loaded += BasePage_Loaded;
        }

        /// <summary>
        /// Animation to play when the page first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// Animation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        /// <summary>
        /// A flag to indicate this should animate out on load
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        /// <summary>
        /// Once page is loaded perform any required animation
        /// </summary>
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
                await AnimateOut();
            else
                await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    await this.SlideAndFadeInFromRight(SlideSeconds);

                    break;
            }
        }

        public async Task AnimateOut()
        {
            if (PageUnLoadAnimation == PageAnimation.None)
                return;

            switch (PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    await this.SlideAndFadeOutToLeft(SlideSeconds);

                    break;
            }
        }
    }

    /// <summary>
    /// A base page with added view model support
    /// </summary>
    public class BasePage<TViewModel> : BasePage
        where TViewModel : BaseViewModel, new()
    {
        private TViewModel _viewModel;

        public BasePage()
        {
            ViewModel = new TViewModel();
        }

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        public TViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel == value)
                    return;

                _viewModel = value;
                DataContext = _viewModel;
            }
        }
    }
}
