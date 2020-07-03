using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPractice.Commands;
using WpfPractice.Security;
using WpfPractice.ViewModels.Base;

namespace WpfPractice.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new RelayParamCommand(async param => await Login(param));
        }

        /// <summary>
        /// Flag if login is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        public ICommand LoginCommand { get; set; }

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
        private async Task Login(object param)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                if (!(param is IHavePassword page))
                    return;

                var pass = page.SecurePassword.UnSecure();
            });
        }
    }
}
