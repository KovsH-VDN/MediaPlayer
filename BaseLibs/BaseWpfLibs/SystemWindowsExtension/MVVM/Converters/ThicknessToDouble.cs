using System.Windows;

namespace SystemExtension.MVVM.Converters
{
    public enum Alignment
    {
        Left,
        Top,
        Right,
        Bottom
    }
    public class ThicknessToDouble : BaseMarkupExtensionConverter<Thickness, double>
    {
        public Alignment Side { get; set; } = Alignment.Left;
        public override double Convert(Thickness value, object parameter = null)
        {
            switch(Side)
            {
                case Alignment.Left:
                    return value.Left;
                case Alignment.Top:
                    return value.Top;
                case Alignment.Right:
                    return value.Right;
                case Alignment.Bottom:
                    return value.Bottom;
                default:
                    return value.Left;
            }
        }
    }
}
