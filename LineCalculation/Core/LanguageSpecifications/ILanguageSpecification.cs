using LineCalculation.Core.Models;

namespace LineCalculation.Core.LanguageSpecifications
{
    public interface ILanguageSpecification
    {
        public CodeStringType GetCodeStringType(string codeLine);
    }
}