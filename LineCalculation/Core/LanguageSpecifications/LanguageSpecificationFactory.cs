using System.Linq;

namespace LineCalculation.Core.LanguageSpecifications
{
    public static class LanguageSpecificationFactory
    {
        private static readonly string[] CLikeExtensions = { ".js", ".cs", ".php", ".java" }; 
        
        public static ILanguageSpecification  GetLanguageSpecification(string fileExtension)
        {
            var normalizedExtension = fileExtension.ToLower();
            
            if (CLikeExtensions.Contains(normalizedExtension))
                return new CLikeLanguageSpecification();
            
            if (normalizedExtension == ".py")
                return new PythonLanguageSpecification();

            return null;
        }
    }
}