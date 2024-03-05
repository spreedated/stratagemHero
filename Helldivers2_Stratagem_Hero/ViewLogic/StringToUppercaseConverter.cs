using neXn.Lib.Wpf.ViewLogic;
using System;
using System.Globalization;

namespace Helldivers2_Stratagem_Hero.ViewLogic
{
    public class StringToUppercaseConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                return str.ToUpper(culture);
            }

            return null;
        }
    }
}
