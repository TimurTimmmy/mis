using System;
using System.Globalization;
using System.Windows.Data;

namespace mis.RBC
{
    public class RadioButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)parameter == (string)value);            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

//xmlns:local2="clr-namespace:mis.RBC"
    //<Window.Resources>
    //    <local2:RadioButtonConverter x:Key="rbConverter"/>
    //</Window.Resources>