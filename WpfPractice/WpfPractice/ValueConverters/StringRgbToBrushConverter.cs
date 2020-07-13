﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using WpfPractice.ValueConverters.Base;

namespace WpfPractice.ValueConverters
{
    // <summary>
    /// A converter that takes in a rgb string and coverts to brush
    /// </summary>
    public class StringRgbToBrushConverter : BaseValueConverter<StringRgbToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush)(new BrushConverter()).ConvertFrom($"#{value}");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}