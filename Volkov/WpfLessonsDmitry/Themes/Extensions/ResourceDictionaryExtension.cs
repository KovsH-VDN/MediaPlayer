using System.Windows;

namespace Themes
{
    public static class ResourceDictionaryExtension
    {
        public static void RemoveResource(this ResourceDictionary dictionary, object key)
        {
            if (dictionary.Contains(key))
                dictionary.Remove(key);
            else
            {
                foreach(var dictionaries in dictionary.MergedDictionaries)
                {
                    dictionaries.RemoveResource(key);
                }
            }
        }
    }
}
