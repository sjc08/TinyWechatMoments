using Asjc.Utils;
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
            var hBitmap = GetHThumbnail(value.ToString());
            var source = Tryer.Try(() => Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions()));
            DeleteObject(hBitmap);
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
