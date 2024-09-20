using Asjc.Utils;
using HandyControl.Controls;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using static Asjc.ThumbnailProvider.ThumbnailProvider;

namespace TinyWechatMoments
{
    public class ThumbnailConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Tryer.Try(() =>
            {
                var hBitmap = GetHThumbnail((string)value);
                var source = Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                DeleteObject(hBitmap);
                return source;
            }, e => Growl.Error(e.Message))!;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
