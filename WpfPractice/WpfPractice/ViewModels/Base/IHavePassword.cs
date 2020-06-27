using System.Security;

namespace WpfPractice.ViewModels.Base
{
    public interface IHavePassword
    {
        public SecureString SecurePassword { get; }
    }
}
