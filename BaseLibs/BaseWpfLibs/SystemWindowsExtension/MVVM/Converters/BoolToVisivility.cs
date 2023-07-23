using System;
using System.Globalization;
using System.Windows;

namespace SystemExtension.MVVM.Converters
{
    public class BoolToVisivility : BaseMarkupExtensionConverter<bool, Visibility>
    {
        public Visibility True { get; set; } = Visibility.Visible;
        public Visibility False { get; set; } = Visibility.Collapsed;

        public override Visibility Convert(bool value, object parameter = null) => value ? True : False;
    }
}