using System;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;
using System.Windows.Media;

namespace GeometryPainter.Controls
{
    public abstract class BaseDynamicRenderer : DynamicRenderer, IDynamicRenderer, ICloneable
    {
        private bool _isManipulating;

        protected sealed override void OnDraw(DrawingContext drawingContext, StylusPointCollection stylusPoints, Geometry geometry, Brush fillBrush)
        {
            ResetDrawing(stylusPoints);
            Draw(drawingContext, stylusPoints, DrawingAttributes);
        }

        protected void ResetDrawing(StylusPointCollection stylusPoints)
        {
            if (!_isManipulating)
            {
                _isManipulating = true;
                StylusDevice currentStylus = Stylus.CurrentStylusDevice;
                this.Reset(currentStylus, stylusPoints);
            }
            _isManipulating = false;
        }

        public abstract void Draw(DrawingContext drawingContext, StylusPointCollection stylusPoints, DrawingAttributes drawingAttributes);
        public abstract void Clear();

        public abstract object Clone();
    }
}
