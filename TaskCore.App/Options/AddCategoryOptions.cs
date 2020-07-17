using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;

namespace TaskCore.App.Options
{
    public class AddCategoryOptions : VerbOptionsBase
    {
        [OptionName("title", Alias="t")]
        public string Title { get; set; }
        
        [OptionName("color", Alias = "c")]
        public string Color { get; set; }
    }
}