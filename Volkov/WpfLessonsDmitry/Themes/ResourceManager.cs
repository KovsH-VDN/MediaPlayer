using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;

namespace Themes
{
    public class ResourceManager : ResourceDictionary
    {
        private static ResourceDictionaryExtended _currentTheme;
        private static ResourceDictionaryExtended _currentContrast;

        public static ResourceData CurrentThemeKey => _currentTheme.ThemeData;
        public static ResourceData CurrentContrastKey => _currentContrast.ThemeData;
        public static IReadOnlyList<ResourceData> ThemeDatas => CurrentThemeManager.Themes.Select(t => t.ThemeData).ToList();
        public static IReadOnlyList<ResourceData> ContrastDatas => CurrentThemeManager.Contrasts.Select(t => t.ThemeData).ToList();
        public static ResourceManager CurrentThemeManager { get; private set; }
        public static ResourceDictionary SetTheme(string key)
        {
            ResourceDictionaryExtended theme = GetTheme(key);
            if (theme is null)
                return CurrentThemeManager;

            _currentTheme = theme;
            return CurrentThemeManager.RebuildResources();
        }
        public static ResourceDictionary SetContrast(string key)
        {
            ResourceDictionaryExtended contrast = GetContrast(key);
            if (contrast is null)
                return CurrentThemeManager;

            _currentContrast = contrast;

            return CurrentThemeManager.RebuildResources();
        }
        public static ResourceDictionaryExtended GetTheme(string key)
        {
            return CurrentThemeManager.Themes.SingleOrDefault(t => t.ThemeData.Key == key);
        }
        public static ResourceDictionaryExtended GetContrast(string key)
        {
            return CurrentThemeManager.Contrasts.SingleOrDefault(c => c.ThemeData.Key == key);
        }


        public ObservableCollection<ResourceDictionary> MainResources { get; }
        public ObservableCollection<ResourceDictionaryExtended> Themes { get; }
        public ObservableCollection<ResourceDictionaryExtended> Contrasts { get; }
        public ResourceManager() : base()
        {
            MainResources = new ObservableCollection<ResourceDictionary>();
            Themes = new ObservableCollection<ResourceDictionaryExtended>();
            Contrasts = new ObservableCollection<ResourceDictionaryExtended>();

            MainResources.CollectionChanged += MainResources_CollectionChanged;
            Themes.CollectionChanged += Themes_CollectionChanged;
            Contrasts.CollectionChanged += Contrasts_CollectionChanged;

            CurrentThemeManager = this;
        }

        private void MainResources_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add && e.NewItems[0] is ResourceDictionary resource)
                MergedDictionaries.Add(resource);
        }
        private void Themes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => SetDictionary(ref _currentTheme, e);
        private void Contrasts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => SetDictionary(ref _currentContrast, e);
        private void SetDictionary(ref ResourceDictionaryExtended dictionary, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action != NotifyCollectionChangedAction.Add || !(e.NewItems[0] is ResourceDictionaryExtended resource))
                return;

            if(dictionary is null)
            {
                dictionary = resource;
                MergedDictionaries.Add(resource);
            }
        }

        private ResourceDictionary RebuildResources()
        {
            MergedDictionaries.Clear();

            foreach (var resource in MainResources)
                MergedDictionaries.Add(resource);

            if (_currentTheme != null)
                MergedDictionaries.Add(_currentTheme);
            if (_currentContrast != null)
                MergedDictionaries.Add(_currentContrast);

            return this;
        }
    }
}
