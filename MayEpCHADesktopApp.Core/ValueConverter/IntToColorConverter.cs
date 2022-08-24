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
    public class IntToColorConverter : MarkupExtension, IValueConverter
    {
        static IntToColorConverter converter;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush solidColorBrush;
            switch (value)
            {
                // PowerOff
                case "1":
                    solidColorBrush = new SolidColorBrush(Colors.Gray);
                    break;
                //PowerOn
                case "2":
                    solidColorBrush = new SolidColorBrush(Colors.Green);
                    break;
                //Disconnect
                case "3":
                    solidColorBrush = new SolidColorBrush(Colors.Gray);
                    break;
                //connected
                case "4":
                    solidColorBrush = new SolidColorBrush(Colors.Green);
                    break;
                //OnProduction
                case "5":
                    solidColorBrush = new SolidColorBrush(Colors.Green);
                    break;
                //Idle
                case "6":
                    solidColorBrush = new SolidColorBrush(Colors.Yellow);
                    break;
                //ErrorOnGoing
                case "7":
                    solidColorBrush = new SolidColorBrush(Colors.Red);
                    break;
                //ErrorOutGoing
   
                default:
                    solidColorBrush = new SolidColorBrush(Colors.Gray);
                    break ;
            }
            return solidColorBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (converter == null) converter = new IntToColorConverter();
            return converter;
        }
    }
}
