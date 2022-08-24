using System;
using System.Collections.Generic;
using System.Linq;

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
    public class StringtoStringStatusMachine : MarkupExtension, IValueConverter
    {
        static StringtoStringStatusMachine converter;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           string Status;
            switch (value)
            {
                // PowerOff
                case "1":
                    Status = "Tắt máy";
                    break;
                //PowerOn
                case "2":
                    Status = "Mở máy";
                    break;
                //Disconnect
                case "3":
                    Status = "Không kết nối";
                    break;
                case "4":
                    Status = "Connected";
                    break;
                //OnProduction
                case "5":
                    Status = "Đang sản xuất";
                    break;
                //Idle
                case "6":
                    Status = "Trạng thái Idle";
                    break;
                //ErrorOnGoing
                case "7":
                    Status = "ErrorOnGoing";
                    break;
                //ErrorOutGoing

                default:
                    Status = "ErrorOutGoing";
                    break;
            }
            return Status;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (converter == null) converter = new StringtoStringStatusMachine();
            return converter;
        }
    }
}

