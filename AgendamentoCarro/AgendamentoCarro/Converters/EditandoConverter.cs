using System;
using System.Globalization;
using Xamarin.Forms;

namespace AgendamentoCarro
{
    public class EditandoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var editando = (bool)value;

            if (editando)
                return Color.Red;
            else
                return Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var editando = (bool)value;

            if (editando)
                return Color.Red;
            else
                return Color.Black;
        }
    }
}
