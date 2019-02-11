using Libraries.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Libraries.Extensibility
{
    public class CommandInfoConverter : IMultiValueConverter
    {
        private const int MIN_LENGTH = 2;
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var commandInfo = default(CommandInfo);

            if (values != default(object[]) && values.Length >= MIN_LENGTH)
            {
                commandInfo = new CommandInfo
                {
                    Input = values[0],
                    Result = values[1]
                };
            }

            return commandInfo;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
