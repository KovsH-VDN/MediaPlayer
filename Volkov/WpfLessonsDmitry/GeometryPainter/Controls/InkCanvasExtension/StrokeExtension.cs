using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace GeometryPainter.Controls
{
    public class StrokeExtension : Stroke
    {
        public IDynamicRenderer DynamicRenderer { get; }

        public StrokeExtension(StylusPointCollection stylusPoints, DrawingAttributes drawingAttributes, IDynamicRenderer dynamicRenderer) : base(stylusPoints, drawingAttributes)
        {
            DynamicRenderer = dynamicRenderer;
        }

        protected override void DrawCore(DrawingContext drawingContext, DrawingAttributes drawingAttributes)
        {
            DynamicRenderer.Clear();
            DynamicRenderer.Draw(drawingContext, StylusPoints, drawingAttributes);
        }
    }
}
