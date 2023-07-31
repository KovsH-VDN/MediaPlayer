using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace GeometryPainter.Controls
{
    public interface IDynamicRenderer
    {
        void Draw(DrawingContext drawingContext, StylusPointCollection stylusPoints, DrawingAttributes drawingAttributes);
        void Clear();
    }
}
