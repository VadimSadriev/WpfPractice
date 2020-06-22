using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfPractice.Commands;
using WpfPractice.ViewModels.Base;

namespace WpfPractice.ViewModels
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        private Window _window;

        /// <summary>
        /// Margin around the window to allow the drop shadow
        /// </summary>
        private int _outerMarginSize = 10;

        /// <summary>
        /// Radius of the edges of the window
        /// </summary>
        private int _windowRadius = 10;
        
        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition _dockPosition = WindowDockPosition.Undocked;

        #endregion

        public WindowViewModel(Window window)
        {
            _window = window;

            _window.StateChanged += (sender, e) =>
            {
                // fire off events for all properties that are affected by resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimizeWindow = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeWindow = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));

            // Fix window resize issue
            new WindowResizer(_window);
        }

        #region Public Properties

        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless => _window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked;
        
        /// <summary>
        /// The window minimum width
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The window maximum height
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// Size of resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// Size of resized border around the window taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);


        /// <summary>
        /// Padding of the inner content of the main window 
        /// </summary>
        public Thickness InnerContentPadding => new Thickness(ResizeBorder);

        /// <summary>
        /// Margin around the window to allow the drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get => Borderless ? 0 : _outerMarginSize;
            set => _outerMarginSize = value;
        }

        /// <summary>
        /// Margin around the window to allow the drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        /// <summary>
        /// Radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get => Borderless ? 0 : _windowRadius;
            set => _windowRadius = value;
        }

        /// <summary>
        /// Radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);


        /// <summary>
        /// The Height of title bar of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        #endregion

        #region Commands

        /// <summary>
        /// Command to minimize the window
        /// </summary>
        public ICommand MinimizeWindow { get; set; }

        /// <summary>
        /// Command to maximize the window
        /// </summary>
        public ICommand MaximizeWindow { get; set; }

        /// <summary>
        /// Command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Command to open the menu command
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion


        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(_window);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }
    }
}