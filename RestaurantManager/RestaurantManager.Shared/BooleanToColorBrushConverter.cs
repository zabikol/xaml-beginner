using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace RestaurantManager.Shared
{
    public class BooleanToColorBrushConverter : DependencyObject, IValueConverter
    {
        public SolidColorBrush True_Color
        {
            get { return (SolidColorBrush)GetValue(True_ColorProperty); }
            set { SetValue(True_ColorProperty, value); }
        }

        public static readonly DependencyProperty True_ColorProperty =
            DependencyProperty.Register(nameof(True_Color), typeof(SolidColorBrush), typeof(BooleanToColorBrushConverter), new PropertyMetadata(new SolidColorBrush(Colors.Green)));

        public SolidColorBrush False_Color
        {
            get { return (SolidColorBrush)GetValue(False_ColorProperty); }
            set { SetValue(False_ColorProperty, value); }
        }

        public static readonly DependencyProperty False_ColorProperty =
            DependencyProperty.Register(nameof(False_Color), typeof(SolidColorBrush), typeof(BooleanToColorBrushConverter), new PropertyMetadata(new SolidColorBrush(Colors.Red)));

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //Default is false, but better habit to use default command
            bool boolValue = default(bool);

            //is the value a bool
            if (value is bool)
            {
                boolValue = (bool)value;
            }
            //is the value a nullable bool
            else if (value is bool?)
            {
                bool? tmp = (bool?)value;
                boolValue = tmp.HasValue ? tmp.Value : default(bool);
            }
            return boolValue ? True_Color : False_Color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is SolidColorBrush)
            {
                return (SolidColorBrush)value == True_Color;
            }

            return default(bool);
        }
    }
}