using System;
using System.Globalization;
using System.Windows.Media;

namespace SystemExtension.MVVM.Converters
{
    public class SolidBrushAlphaSetting : BaseMarkupExtensionConverter<SolidColorBrush, SolidColorBrush>
    {
        private double _percent = 100;
        public double Percent
        {
            get => _percent;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Значение не может быть меньше 0 и больше 100", $"{this.GetType().FullName}.{nameof(Percent)}");
                _percent = value;
            }
        }

        public override SolidColorBrush Convert(SolidColorBrush value, object parameter = null)
        {
            var asd = new SolidColorBrush(Color.FromArgb((byte)(255 * Percent / 100), value.Color.R, value.Color.G, value.Color.B));
            return asd;
        }
    }
}