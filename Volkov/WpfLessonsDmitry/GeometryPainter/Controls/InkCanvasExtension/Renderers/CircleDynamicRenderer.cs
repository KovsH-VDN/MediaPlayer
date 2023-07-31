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
    public class CircleDynamicRenderer : BaseDynamicRenderer
    {
        public CircleDynamicRenderer(DrawingAttributes drawingAttributes)
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

            Point startpoint = StartPoint.Value.ToPoint();
            Point endPoint = stylusPoints.Last().ToPoint();

            double centreX = (endPoint.X + startpoint.X) / 2;
            double centreY = (endPoint.Y + startpoint.Y) / 2;

            Point centre = new Point(centreX, centreY);

            double radius = Math.Sqrt(Math.Pow(endPoint.X - startpoint.X, 2) + Math.Pow(endPoint.Y - startpoint.Y, 2)) / 2;

            drawingContext.DrawEllipse(Brushes.Transparent, pen, centre, radius, radius);
        }

        public override void Clear() => StartPoint = null;
        public override object Clone() => new CircleDynamicRenderer(DrawingAttributes.Clone()) { StartPoint = StartPoint };
    }
}
