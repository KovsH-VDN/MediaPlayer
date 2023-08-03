using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Themes
{
    public class ResourceManagerHelper : DependencyObject
    {
        public static readonly DependencyProperty SetThemeKeyProperty;
        public static readonly DependencyProperty SetContrastKeyProperty;
        static ResourceManagerHelper()
        {
            SetThemeKeyProperty = DependencyProperty.RegisterAttached("SetThemeKey", typeof(string), typeof(ResourceManagerHelper), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(SetThemeKeyPropertyChanged)) { AffectsRender = true });
            SetContrastKeyProperty = DependencyProperty.RegisterAttached("SetContrastKey", typeof(string), typeof(ResourceManagerHelper), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(SetContrastKeyPropertyChanged)) { AffectsRender = true });
        }

        private static void SetContrastKeyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is FrameworkElement frameworkElement))
                return;

            if (e.NewValue is null)
                return;

            frameworkElement.Resources = ResourceManager.GetContrast(e.NewValue.ToString());
        }
        private static void SetThemeKeyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is FrameworkElement frameworkElement))
                return;

            if (e.NewValue is null)
                return;

            frameworkElement.Resources = ResourceManager.GetTheme(e.NewValue.ToString());
        }

        public static string GetSetThemeKey(UIElement uIElement)
        {
            return (string)uIElement.GetValue(SetThemeKeyProperty);
        }
        public static string GetSetContrastKey(UIElement uIElement)
        {
            return (string)uIElement.GetValue(SetContrastKeyProperty);
        }
        public static void SetSetThemeKey(UIElement uIElement, string value)
        {
            uIElement.SetValue(SetThemeKeyProperty, value);
        }
        public static void SetSetContrastKey(UIElement uIElement, string value)
        {
            uIElement.SetValue(SetContrastKeyProperty, value);
        }


    }
}
