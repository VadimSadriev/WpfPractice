using System.Security;

namespace WpfPractice.Core.ViewModels.Base
{
    public interface IHavePassword
    {
        public SecureString SecurePassword { get; }
    }
}
