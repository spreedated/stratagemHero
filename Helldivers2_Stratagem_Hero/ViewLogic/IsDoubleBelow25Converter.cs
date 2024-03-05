using neXn.Lib.Wpf.ViewLogic;
using System;
using System.Globalization;

namespace Helldivers2_Stratagem_Hero.ViewLogic
{
    public class IsDoubleBelow25Converter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
            {
                return d <= 250d;
            }

            return false;
        }
    }
}
