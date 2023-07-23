using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace SystemExtension.MVVM.Converters
{
    public class EnumDescription : BaseMarkupExtensionConverter<Enum, string>
    {
        public override string Convert(Enum value, object parameter = null) => EnumService.GetDescription(value);
    }
    public static class EnumService
    {
        public static IEnumerable<T> CreatEnumCollection<T>() => Enum.GetValues(typeof(T)).Cast<T>();
        public static T GetNextEnumValue<T>(T value)
        {
            IList<T> values = CreatEnumCollection<T>().ToList();

            int index = values.IndexOf(value) + 1;

            if (index >= values.Count)
                index = 0;

            return values[index];
        }
        public static string GetDescription(Enum myEnum)
        {
            if (myEnum == null) return null;

            FieldInfo fieldInfo = myEnum.GetType().GetField(myEnum.ToString());
            DescriptionAttribute attribute = fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute != null ? attribute.Description : myEnum.ToString();
        }
    }
}