using System;
using System.Linq;
using System.Windows;

namespace Themes
{
    public static class ApplicationExtension
    {
        public static void SetTheme(this Application application, string key) => application.UpdateApplicationResources(key, ResourceManager.SetTheme);
        public static void SetContrast(this Application application, string key) => application.UpdateApplicationResources(key, ResourceManager.SetContrast);

        private static void UpdateApplicationResources(this Application application, string key, Func<string, ResourceDictionary> getDictionary)
        {
            ResourceDictionary dictionary = application.Resources.MergedDictionaries.SingleOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("pack://application:,,,/Themes;component/Themes/Generic.xaml"));
            _ = application.Resources.MergedDictionaries.Remove(dictionary);

            ResourceDictionary newDictionary = getDictionary(key);
            application.Resources.MergedDictionaries.Add(newDictionary);
        }
    }
}
