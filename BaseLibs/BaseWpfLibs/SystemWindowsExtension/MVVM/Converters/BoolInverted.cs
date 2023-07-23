using System;
using System.Globalization;

namespace SystemExtension.MVVM.Converters
{
    public class BoolInverted : BaseMarkupExtensionConverter<bool, bool>
    {
        public override bool Convert(bool value, object parameter = null) => !value;
    }
}