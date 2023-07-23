
namespace SystemExtension.MVVM.Converters
{
    public class EmptyString : BaseMarkupExtensionConverter<string, string>
    {
        public string DefaultText { get; set; } = "Введите текст...";
        public bool NeedToConvertBack { get; set; }
        
        public override string Convert(string value, object parameter = null) => 
            value != null && value != string.Empty ? value :
            parameter != null && parameter.ToString() != string.Empty ? parameter.ToString() :
            DefaultText;
        public override string ConvertBack(string value, object parameter = null) => NeedToConvertBack ? value : base.ConvertBack(value, parameter);
    }
}