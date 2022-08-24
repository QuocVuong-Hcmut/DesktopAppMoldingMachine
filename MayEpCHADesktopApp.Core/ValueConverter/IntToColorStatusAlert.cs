using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace MayEpCHADesktopApp.Core.ValueConverter
{
    public class IntToColorStatusAlert:MarkupExtension, IValueConverter
    {
        static IntToColorStatusAlert converter;
        public object Convert (object value,Type targetType,object parameter,CultureInfo culture)
        {
            SolidColorBrush solidColorBrush;
            switch ( value )
            {
                // PowerOff
                case 0:
                    solidColorBrush=new SolidColorBrush(Colors.Yellow);
                    break;
                //PowerOn
                case 1:
                    solidColorBrush=new SolidColorBrush(Colors.Green);
                    break;
                    default:
                    solidColorBrush=new SolidColorBrush(Colors.Yellow);
                    break;
            }
            return solidColorBrush;
        }

        public object ConvertBack (object value,Type targetType,object parameter,CultureInfo culture)
        {
            throw new NotImplementedException( );
        }

        public override object ProvideValue (IServiceProvider serviceProvider)
        {
            if ( converter==null ) converter=new IntToColorStatusAlert( );
            return converter;
        }
    }
}
