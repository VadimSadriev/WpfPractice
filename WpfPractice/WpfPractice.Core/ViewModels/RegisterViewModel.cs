using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPractice.Core.Commands;
using WpfPractice.Core.DataModels;
using WpfPractice.Core.Ioc;
using WpfPractice.Core.Security;
using WpfPractice.Core.ViewModels.Base;

namespace WpfPractice.Core.ViewModels
{
    /// <summary>
    /// View model for register page
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
        {
            RegisterCommand = new RelayParamCommand(async param => await RegisterAsync(param));
            LoginCommand = new RelayCommand(async () => await LoginAsync());
        }

        /// <summary>
        /// Flag if login is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }

        /// <summary>
        /// Command to log in
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// Command to register new account
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        public SecureString Password { get; set; }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="param"><see cref="SecureString"/> passed from view</param>
        private async Task RegisterAsync(object param)
        {
            await RunCommand(() => RegisterIsRunning, async () =>
            {
                await Task.Delay(5000);
            });
        }

        /// <summary>
        /// Takes the user to login page
        /// </summary>
        private async Task LoginAsync()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
        }
    }
}
