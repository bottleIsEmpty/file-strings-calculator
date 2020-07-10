using System.Text.RegularExpressions;
using LineCalculation.Core.Models;

namespace LineCalculation.Core.LanguageSpecifications
{
    public class CLikeLanguageSpecification : ILanguageSpecification
    {
        private bool _multilineCommentStarted = false;

        public CodeStringType GetCodeStringType(string codeLine)
        {
            var normalized = Regex.Replace(codeLine.Trim(), "(\\\".*\\\")|(\\\'.*\\\')", ""); 

            if (string.IsNullOrWhiteSpace(codeLine))
                return CodeStringType.Empty;

            if (!_multilineCommentStarted)
            {
                if (normalized.StartsWith("//"))
                    return CodeStringType.Comment;

                if (normalized.Contains("//"))
                    return CodeStringType.Mixed;

                if (normalized.StartsWith("/*"))
                {
                    if (normalized.EndsWith("*/"))
                        return CodeStringType.Comment;

                    if (normalized.Contains("*/"))
                        return CodeStringType.Mixed;

                    _multilineCommentStarted = true;
                    return CodeStringType.Comment;
                }

                if (normalized.Contains("/*"))
                {
                    _multilineCommentStarted = true;
                    return CodeStringType.Mixed;
                }
            } 
            
            if (_multilineCommentStarted) {
                if (normalized.EndsWith("*/"))
                {
                    _multilineCommentStarted = false;
                    return CodeStringType.Comment;
                }
                
                if (normalized.Contains("*/"))
                {
                    _multilineCommentStarted = false;
                    return CodeStringType.Mixed;
                }

                return CodeStringType.Comment;
            }

            return CodeStringType.Code;
        }
    }
}