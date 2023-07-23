using System;
using System.Globalization;
using System.Windows;

namespace SystemExtension.MVVM.Converters
{
    public enum ConcatLocation
    {
        Before,
        After
    }
    public class StringConcat : BaseMarkupExtensionConverter<string, string>
    {
        public ConcatLocation ConcatLocation { get; set; } = ConcatLocation.After;
        public string Value { get; set; } = "";

        public override string Convert(string value, object parameter = null) =>
            ConcatLocation == ConcatLocation.Before ? $"{Value}{value}" : $"{value}{Value}";
    }
}