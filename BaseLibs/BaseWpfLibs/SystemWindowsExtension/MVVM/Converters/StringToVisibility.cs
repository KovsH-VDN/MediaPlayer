using System;
using System.Globalization;
using System.Windows;

namespace SystemExtension.MVVM.Converters
{
    public class StringToVisibility : BaseMarkupExtensionConverter<string, Visibility>
    {
        public Visibility NullOrEmpty { get; set; } = Visibility.Collapsed;
        public Visibility NotEmpty { get; set; } = Visibility.Visible;

        public override Visibility Convert(string value, object parameter = null) => value == null || value == "" ? NullOrEmpty : NotEmpty;
    }
}