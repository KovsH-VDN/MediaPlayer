using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GeometryPainter.Controls
{
    public class InkCanvasExtension : InkCanvas
    {
        private BaseDynamicRenderer _baseDynamicRenderer;
        public BaseDynamicRenderer BaseDynamicRenderer
        {
            get => _baseDynamicRenderer;
            set
            {
                _baseDynamicRenderer = value;
                DynamicRenderer = value;
            }
        }
        static InkCanvasExtension()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InkCanvasExtension), new FrameworkPropertyMetadata(typeof(InkCanvasExtension)));
        }
        public InkCanvasExtension() : base()
        {
            BaseDynamicRenderer = new RectangleDynamicRenderer(DefaultDrawingAttributes);
            //BaseDynamicRenderer = new CircleDynamicRenderer(DefaultDrawingAttributes);
            //BaseDynamicRenderer = new LineDynamicRenderer(DefaultDrawingAttributes);
        }

        protected override void OnStrokeCollected(InkCanvasStrokeCollectedEventArgs e)
        {
            Strokes.Remove(e.Stroke);
            StylusPointCollection stylusPoints = new StylusPointCollection();
            var point1 = e.Stroke.StylusPoints.First();
            var point2 = e.Stroke.StylusPoints.Last();
            if (point1 == point2)
            {
                BaseDynamicRenderer.Clear();
                return;
            }

            stylusPoints.Add(point1);
            stylusPoints.Add(point2);
            StrokeExtension stroke = new StrokeExtension(stylusPoints, DefaultDrawingAttributes.Clone(), BaseDynamicRenderer);
            Strokes.Add(stroke);

            base.OnStrokeCollected(new InkCanvasStrokeCollectedEventArgs(stroke));

            BaseDynamicRenderer.Clear();
        }
        protected override void OnSelectionChanging(InkCanvasSelectionChangingEventArgs e)
        {
            //e.Cancel = true;
        }
    }
}