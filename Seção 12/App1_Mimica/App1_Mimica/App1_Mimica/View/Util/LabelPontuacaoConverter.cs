using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.View.Util
{
    public class LabelPontuacaoConverter : IValueConverter
    {

        // view > VieModel (Dados)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Byte Pontuacao = Byte.Parse(value as string);
            if ((byte)value == 0)
            {
                return "Palavra";
            }
            else
            {
                return "Palavra - Pontuacao :" + value;
            }
        }

        // ViewModel (Dados) > view 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
