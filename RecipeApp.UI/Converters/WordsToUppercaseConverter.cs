using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace RecipeApp.UI.Converters
{
    public class WordsToUppercaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string valueString)) return string.Empty;

            var words = valueString.Split(' ');
            var returnWords = new string[words.Length];

            for (var x=0; x < words.Length; x++)
            {
                var characters = words[x].ToCharArray();
                characters[0] = char.ToUpper(characters[0]);
                returnWords[x] = new string(characters);
            }

            return string.Join(" ", returnWords);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
