using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfPractice.Core.Ioc;

namespace WpfPractice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // setup DI
            IoC.Setup();

            // show main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
