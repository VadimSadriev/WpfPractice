using System;
using System.Collections.Generic;
using System.Text;
using WpfPractice.Core.Ioc;
using WpfPractice.Core.ViewModels;

namespace WpfPractice.ViewModels
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
    }
}
