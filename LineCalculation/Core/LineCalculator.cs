using System;
using System.Collections.Generic;
using System.IO;
using LineCalculation.Core.LanguageSpecifications;
using LineCalculation.Core.Models;

namespace LineCalculation.Core
{
    public class LineCalculator
    {
        private readonly ILanguageSpecification _specification;
        private readonly IEnumerable<string> _lines;
        
        public LineCalculator(string filePath)
        {
            _specification = LanguageSpecificationFactory.GetLanguageSpecification(Path.GetExtension(filePath));

            if (_specification == null || !File.Exists(filePath))
                throw new Exception("Некорректный файл.");
            
            _lines = File.ReadLines(filePath);
        }
        
        public CalculationResult CalculateLines()
        {
            var result = new CalculationResult();

            foreach (var line in _lines)
            {
                var lineType = _specification.GetCodeStringType(line);

                switch (lineType)
                {
                    case CodeStringType.Empty:
                        result.EmptyLines++;
                        break;
                    case CodeStringType.Code:
                        result.CodeLines++;
                        break;
                    case CodeStringType.Comment:
                        result.CommentLines++;
                        break;
                    case CodeStringType.Mixed:
                        result.HybridLines++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return result;
        }
    }
}