﻿using System;
using System.Diagnostics;
using System.Globalization;
using WpfPractice.Core.DataModels;
using WpfPractice.Pages;
using WpfPractice.ValueConverters.Base;

namespace WpfPractice.ValueConverters
{
    /// <summary>
    /// Converts <see cref="ApplicationPage"/> to the view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();
                case ApplicationPage.Chat:
                    return new ChatPage();
                case ApplicationPage.Register:
                    return new RegisterPage();
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
