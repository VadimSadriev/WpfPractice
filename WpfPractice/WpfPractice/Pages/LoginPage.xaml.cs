﻿using System.Security;
using System.Windows.Controls;
using WpfPractice.Core.ViewModels;
using WpfPractice.Core.ViewModels.Base;

namespace WpfPractice.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
