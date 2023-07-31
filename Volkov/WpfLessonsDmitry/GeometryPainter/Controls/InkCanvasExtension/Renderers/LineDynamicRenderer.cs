using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace GeometryPainter.Controls
{
    public class LineDynamicRenderer : BaseDynamicRenderer
    {
        public LineDynamicRenderer(DrawingAttributes drawingAttributes)
        {
            DrawingAttributes = drawingAttributes;
        }

        private StylusPoint? StartPoint { get; set; }

        public override void Draw(DrawingContext drawingContext, StylusPointCollection stylusPoints, DrawingAttributes drawingAttributes)
        {
            if (stylusPoints.Count == 0)
                return;

            if (StartPoint is null && stylusPoints.Count != 0)
                StartPoint = stylusPoints.First();

            if (StartPoint is null || stylusPoints.Count < 2)
                return;

            Pen pen = new Pen(new SolidColorBrush(drawingAttributes.Color), drawingAttributes.Width);

            drawingContext.DrawLine(pen, StartPoint.Value.ToPoint(), stylusPoints.Last().ToPoint());
        }

        public override void Clear() => StartPoint = null;
        public override object Clone() => new LineDynamicRenderer(DrawingAttributes.Clone()) { StartPoint = StartPoint };
    }
}
