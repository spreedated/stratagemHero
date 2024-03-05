using neXn.Lib.Wpf.ViewLogic;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Helldivers2_Stratagem_Hero.ViewLogic
{
    public class ByteArrayToImageSourceConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            if (value is byte[] b && b.Length != 0)
            {
                BitmapImage biImg = new();
                MemoryStream ms = new(b);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();

                return (ImageSource)biImg;
            }

            return null;
        }
    }
}
