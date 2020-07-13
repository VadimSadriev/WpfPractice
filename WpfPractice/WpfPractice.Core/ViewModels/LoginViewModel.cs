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
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new RelayParamCommand(async param => await LoginAsync(param));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }

        /// <summary>
        /// Flag if login is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

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
        /// Log in User
        /// </summary>
        /// <param name="param"><see cref="SecureString"/> passed from view</param>
        /// <returns></returns>
        private async Task LoginAsync(object param)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                if (!(param is IHavePassword page))
                    return;

                var pass = page.SecurePassword.UnSecure();
            });
        }

        /// <summary>
        /// Takes the user to register page
        /// </summary>
        private async Task RegisterAsync()
        {
            IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;
            return;
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Register;
        }
    }
}
