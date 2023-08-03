using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Themes;

namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeThemeButtons();
        }

        private void InitializeThemeButtons()
        {
            CreateThemeButtons(ResourceManager.ThemeDatas, ThemeButton_Click);
            CreateThemeButtons(ResourceManager.ContrastDatas, ContrastButton_Click);
        }
        private void CreateThemeButtons(IReadOnlyList<ResourceData> themeDatas, RoutedEventHandler click)
        {
            foreach (ResourceData data in themeDatas)
            {
                Button button = CreateThemeButton(data, click);
                _ = stack.Children.Add(button);
            }
        }
        private Button CreateThemeButton(ResourceData data, RoutedEventHandler click)
        {
            Button button = new Button
            {
                Background = data.MainBrush,
                Content = data.Key
            };

            button.Click += click;
            return button;
        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button is null)
                return;

            Application.Current.SetTheme(button.Content.ToString());
        }
        private void ContrastButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button is null)
                return;

            Application.Current.SetContrast(button.Content.ToString());
        }
    }
}