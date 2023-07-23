using System;
using System.Globalization;

namespace SystemExtension.MVVM.Converters
{
    public class BoolToDouble : BaseMarkupExtensionConverter<bool, double>
    {
        public double True { get; set; } = 1;
        public double False { get; set; } = 0;
        public override double Convert(bool value, object parameter = null) => value ? True : False;
    }
}
