using System;
using System.Globalization;
using System.Windows;

namespace SystemExtension.MVVM.Converters
{
    public class NullObjectToVisivility : BaseMarkupExtensionConverter<object, Visibility>
    {
        public Visibility Null { get; set; } = Visibility.Collapsed;
        public Visibility NotNull { get; set; } = Visibility.Visible;

        public override Visibility Convert(object value, object parameter = null) => value == null ? Null : NotNull;
    }
}