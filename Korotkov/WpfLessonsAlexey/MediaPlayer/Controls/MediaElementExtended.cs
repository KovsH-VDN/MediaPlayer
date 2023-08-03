using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using SystemExtension.MVVM.Commands;

namespace MediaPlayer.Controls
{
    /// <summary>
    /// Выполните шаги 1a или 1b, а затем 2, чтобы использовать этот пользовательский элемент управления в файле XAML.
    ///
    /// Шаг 1a. Использование пользовательского элемента управления в файле XAML, существующем в текущем проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MediaPlayer"
    ///
    ///
    /// Шаг 1б. Использование пользовательского элемента управления в файле XAML, существующем в другом проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MediaPlayer;assembly=MediaPlayer"
    ///
    /// Потребуется также добавить ссылку из проекта, в котором находится файл XAML,
    /// на данный проект и пересобрать во избежание ошибок компиляции:
    ///
    ///     Щелкните правой кнопкой мыши нужный проект в обозревателе решений и выберите
    ///     "Добавить ссылку"->"Проекты"->[Поиск и выбор проекта]
    ///
    ///
    /// Шаг 2)
    /// Теперь можно использовать элемент управления в файле XAML.
    ///
    ///     <MyNamespace:MediaElementExtended/>
    ///
    /// </summary>
    public class MediaElementExtended : MediaElement
    {
        public static readonly DependencyProperty IsPlayProperty;
        public static readonly DependencyProperty PositionProperty;

        public static readonly DependencyProperty PlayCommandProperty;
        public static readonly DependencyProperty PauseCommandProperty;
        public static readonly DependencyProperty StopCommandProperty;

        static MediaElementExtended()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MediaElementExtended), new FrameworkPropertyMetadata(typeof(MediaElementExtended)));

            IsPlayProperty = DependencyProperty.Register(nameof(IsPlay), typeof(bool), typeof(MediaElementExtended));
            PositionProperty = DependencyProperty.Register(nameof(Position), typeof(TimeSpan), typeof(MediaElementExtended));
            PlayCommandProperty = DependencyProperty.Register(nameof(PlayCommand), typeof(ICommand), typeof(MediaElementExtended));
            PauseCommandProperty = DependencyProperty.Register(nameof(PauseCommand), typeof(ICommand), typeof(MediaElementExtended));
            StopCommandProperty = DependencyProperty.Register(nameof(StopCommand), typeof(ICommand), typeof(MediaElementExtended));
        }

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

        public MediaElementExtended()
        {
            PlayCommand = new DelegateCommand(Play);
            PauseCommand = new DelegateCommand(Pause);
            StopCommand = new DelegateCommand(Stop);
        }

        private new void Play()
        {
            if (Source is null)
                return;
            IsPlay = true;
            base.Play();
        }

        private new void Pause()
        {
            IsPlay = false;
            base.Pause();
        }

        private new void Stop()
        {
            IsPlay = false;
            base.Stop();
        }
    }
}
