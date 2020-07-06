using Ninject;
using System;
using System.Collections.Generic;
using System.Text;
using WpfPractice.Core.ViewModels;

namespace WpfPractice.Core.Ioc
{
    /// <summary>
    /// The IoC container for application
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// Kernel for IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// Returns service of type <see cref="{T}"/> from Di
        /// </summary>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        /// <summary>
        /// Sets up IoC container
        /// </summary>
        public static void Setup()
        {
            // bind all required view models
            BindViewModels();
        }

        /// <summary>
        /// Bind all singleton viewmodels
        /// </summary>
        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
    }
}
