using System.Text.RegularExpressions;
using LineCalculation.Core.Models;

namespace LineCalculation.Core.LanguageSpecifications
{
    public class PythonLanguageSpecification : ILanguageSpecification
    {
        public CodeStringType GetCodeStringType(string codeLine)
        {
            var trimmed = codeLine.Trim();

            if (string.IsNullOrWhiteSpace(codeLine))
                return CodeStringType.Empty;

            if (codeLine.StartsWith("#"))
                return CodeStringType.Comment;
            
            var lineWithoutStringLiterals = Regex.Replace(trimmed, "(\".*\")|(\'.*\')", "");

            return lineWithoutStringLiterals.Contains("#") ? CodeStringType.Mixed : CodeStringType.Code;
        }
    }
}