using GUI_20212202_AXJ0GV.Client.Logic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GUI_20212202_AXJ0GV.Client.Converter
{
    public class HealthBarValueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double number = (value as GameLogic).Player.Health;
            if (number >= 80)
            {
                return Brushes.Green;
            }
            else if(number>30 && number<80)
            {
                return Brushes.Yellow;
            }
            else
            {
                return Brushes.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
