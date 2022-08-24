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
    public class IntToIconAlert: MarkupExtension, IValueConverter
    {
        static IntToIconAlert converter;
        public object Convert (object value,Type targetType,object parameter,CultureInfo culture)
        {
            string NameIcon;
            switch ( value )
            {
                // PowerOff
                case 0:
                    NameIcon="ExclamationTriangle";
                    break;
                //PowerOn
                case 1:
                    NameIcon="CheckCircle";
                    break;

                default:
                    NameIcon="ExclamationTriangle";
                    break;
            }
            return NameIcon;
        }

        public object ConvertBack (object value,Type targetType,object parameter,CultureInfo culture)
        {
            throw new NotImplementedException( );
        }

        public override object ProvideValue (IServiceProvider serviceProvider)
        {
            if ( converter==null ) converter=new IntToIconAlert( );
            return converter;
        }
    }
}
