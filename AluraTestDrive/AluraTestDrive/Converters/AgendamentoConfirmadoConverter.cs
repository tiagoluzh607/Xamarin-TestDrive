﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AluraTestDrive.Converters
{
    class AgendamentoConfirmadoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool confirmado = (bool)value;

            if (confirmado)
            {
                return Color.DarkGreen;
            }
            else
            {
                return Color.DarkRed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
