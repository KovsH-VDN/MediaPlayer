using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Media;

namespace SystemExtension.MVVM.Converters
{
    public class SolidBrushToneSetting : SolidBrushAlphaSetting
    {
        public bool Lighten { get; set; }
        public override SolidColorBrush Convert(SolidColorBrush value, object parameter = null) =>
            new SolidColorBrush(Color.FromArgb(value.Color.A, Transform(value.Color.R), Transform(value.Color.G), Transform(value.Color.B)));

        private byte Transform(double color)
        {
            double res;

            if (Lighten)
                res = color + color * Percent / 100;
            else
                res = color - color * Percent / 100;

            return res < 0 ? (byte)0 : res > 255 ? (byte)255 : (byte)res;
        }
    }
}