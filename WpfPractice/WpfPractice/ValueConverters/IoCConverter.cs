using Ninject;
using System;
using System.Diagnostics;
using System.Globalization;
using WpfPractice.Core.DataModels;
using WpfPractice.Core.Ioc;
using WpfPractice.Core.ViewModels;
using WpfPractice.Pages;
using WpfPractice.ValueConverters.Base;

namespace WpfPractice.ValueConverters
{
    /// <summary>
    /// Converts string name to a service from IoC
    /// </summary>
    public class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)parameter)
            {
                case nameof(ApplicationViewModel):
                    return IoC.Get<ApplicationViewModel>();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
