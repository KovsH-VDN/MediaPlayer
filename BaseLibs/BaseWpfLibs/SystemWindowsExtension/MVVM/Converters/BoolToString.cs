using System;
using System.Globalization;

namespace SystemExtension.MVVM.Converters
{
    public class BoolToString : BaseMarkupExtensionConverter<bool, string>
    {
        public string True { get; set; } = "Правда";
        public string False { get; set; } = "Ложь";

        public override string Convert(bool value, object parameter = null) => value ? True : False;
    }
}