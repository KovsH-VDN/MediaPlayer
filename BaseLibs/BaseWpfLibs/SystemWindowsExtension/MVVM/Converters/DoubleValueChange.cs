using System;
using System.Globalization;

namespace SystemExtension.MVVM.Converters
{
    public enum ChangeMode
    {
        Value,
        Percent
    }
    public class DoubleValueChange : BaseMarkupExtensionConverter<double, double>
    {
        public ChangeMode ChangeMode { get; set; } = ChangeMode.Value;
        public double Value { get; set; } = 0;
        public bool IsIncrease { get; set; } = true;

        public override double Convert(double value, object parameter = null)
        {
            if(ChangeMode == ChangeMode.Value)
                return IsIncrease ? value + Value : value - Value;
            else
                return IsIncrease ? value + GetPercent(value) : value - GetPercent(value);
        }

        private double GetPercent(double value) => value * Value / 100;
    }
}