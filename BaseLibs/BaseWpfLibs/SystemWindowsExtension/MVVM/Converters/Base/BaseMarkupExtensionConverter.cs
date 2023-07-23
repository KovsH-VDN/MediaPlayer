using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace SystemExtension.MVVM.Converters
{
    /// <summary>
    /// Представляет бызовый класс для конвертера, используемого в качестве расширения разметки.
    /// </summary>
    /// <typeparam name="Input">Конвертируемый тип</typeparam>
    /// <typeparam name="Output">Целевой тип</typeparam>
    public abstract class BaseMarkupExtensionConverter<Input, Output> : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Преобразует значение.
        /// </summary>
        /// <param name="value">Значение, произведенное исходной привязкой.</param>
        /// <param name="targetType">Тип целевого свойства привязки.</param>
        /// <param name="parameter">Используемый параметр преобразователя.</param>
        /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
        /// <returns>Преобразованное значение. Если этот метод возвращает null, используется допустимое значение NULL.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Input input)
                return Convert(input, parameter);

            return null;
        }
        public abstract Output Convert(Input value, object parameter = null);
        /// <summary>
        /// Преобразует значение.
        /// </summary>
        /// <param name="value">Значение, произведенное исходной привязкой.</param>
        /// <param name="targetType">Тип целевого свойства привязки.</param>
        /// <param name="parameter">Используемый параметр преобразователя.</param>
        /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
        /// <returns>Преобразованное значение. Если этот метод возвращает null, используется допустимое значение NULL.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => ConvertBack((Output)value, parameter);
        public virtual Input ConvertBack(Output value, object parameter = null) => throw new NotImplementedException();
        /// <summary>
        /// Возвращает объект, предоставляемый как конвертер целевого свойства привязки для данного расширения разметки.
        /// </summary>
        /// <param name="serviceProvider">Вспомогательный объект поставщика служб, способный предоставлять службы для расширения разметки.</param>
        /// <returns>Значение объекта, которое необходимо присвоить свойству, где применяется расширение.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
