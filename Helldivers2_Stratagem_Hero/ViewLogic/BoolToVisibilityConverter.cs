using neXn.Lib.Wpf.ViewLogic;
using System;
using System.Globalization;
using System.Windows;

namespace Helldivers2_Stratagem_Hero.ViewLogic
{
    public class BoolToVisibilityConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return b ? Visibility.Visible : Visibility.Hidden;
            }

            return Visibility.Visible;
        }
    }
}
