using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaPlayer.Controls
{
    public class MediaElementExtension : MediaElement
    {
        public static readonly DependencyProperty IsPausedProperty;
        public static readonly DependencyProperty PositionProperty;

        public static readonly DependencyProperty PlayCommandProperty;
        public static readonly DependencyProperty PauseCommandProperty;
        public static readonly DependencyProperty StopCommandProperty;

        public ICommand PlayCommand
        {
            get => (ICommand)GetValue(PlayCommandProperty);
            private set => SetValue(PlayCommandProperty, value);
        }
        public ICommand PauseCommand
        {
            get => (ICommand)GetValue(PauseCommandProperty);
            private set => SetValue(PauseCommandProperty, value);
        }
        public ICommand StopCommand
        {
            get => (ICommand)GetValue(StopCommandProperty);
            private set => SetValue(StopCommandProperty, value);
        }
        public bool IsPaused
        {
            get => (bool)GetValue(IsPausedProperty);
            private set => SetValue(IsPausedProperty, value);
        }
        public new TimeSpan Position
        {
            get => (TimeSpan)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }

        static MediaElementExtension()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MediaElementExtension), new FrameworkPropertyMetadata(typeof(MediaElement)));
        }
    }
}
