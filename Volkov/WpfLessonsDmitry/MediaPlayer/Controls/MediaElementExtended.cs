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
using System.Windows.Threading;
using SystemExtension.MVVM.Commands;

namespace MediaPlayer.Controls
{
    public class MediaElementExtended : MediaElement
    {
        private const int PositionUpdateDelay = 250; // ms
        private DispatcherTimer _positionTimer;

        public static readonly DependencyProperty IsPlayProperty;
        public static readonly DependencyProperty PositionProperty;
        public static readonly DependencyProperty PlayCommandProperty;
        public static readonly DependencyProperty PauseCommandProperty;
        public static readonly DependencyProperty StopCommandProperty;


        public bool IsPlay
        {
            get => (bool)GetValue(IsPlayProperty);
            private set => SetValue(IsPlayProperty, value);
        }
        public new TimeSpan Position
        {
            get => (TimeSpan)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }
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

        static MediaElementExtended()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MediaElementExtended), new FrameworkPropertyMetadata(typeof(MediaElement)));

            IsPlayProperty = DependencyProperty.Register(nameof(IsPlay), typeof(bool), typeof(MediaElementExtended));
            PositionProperty = DependencyProperty.Register(nameof(Position), typeof(TimeSpan), typeof(MediaElementExtended));
            PlayCommandProperty = DependencyProperty.Register(nameof(PlayCommand), typeof(ICommand), typeof(MediaElementExtended));
            PauseCommandProperty = DependencyProperty.Register(nameof(PauseCommand), typeof(ICommand), typeof(MediaElementExtended));
            StopCommandProperty = DependencyProperty.Register(nameof(StopCommand), typeof(ICommand), typeof(MediaElementExtended));
        }
        public MediaElementExtended()
        {
            InitializeCommands();

            _positionTimer = new DispatcherTimer();
            _positionTimer.Interval = new TimeSpan(0, 0, 0, 0, PositionUpdateDelay);
            _positionTimer.Tick += UpdatepositionDependencyProperty;

            MediaOpened += MediaElementExtended_MediaOpened;
        }

        private void MediaElementExtended_MediaOpened(object sender, RoutedEventArgs e)
        {
            ;
        }

        private void InitializeCommands()
        {
            PlayCommand = new DelegateCommand(Play, p => CanPlay());
            PauseCommand = new DelegateCommand(Pause, p => CanStop());
            StopCommand = new DelegateCommand(Stop, p => CanStop());
        }

        private new void Play()
        {
            if (Source is null)
                return;

            IsPlay = true;
            base.Play();
            _positionTimer.Start();
        }
        private new void Pause()
        {
            IsPlay = false;
            base.Pause();
            _positionTimer.Stop();
        }
        private new void Stop()
        {
            IsPlay = false;
            base.Stop();
            _positionTimer.Stop();
        }

        private bool CanPlay() => !IsPlay && Source != null;
        private bool CanStop() => IsPlay;

        private void UpdatepositionDependencyProperty(object sender, EventArgs e) => Position = base.Position;

    }
}
