using System;
using System.IO;
using System.Reflection;
using FluentAssertions;
using LineCalculation.Core;
using LineCalculation.Core.Models;
using NUnit.Framework;

namespace LineCalculationTests
{
    public class LineCalculatorTests
    {
        private LineCalculator _calculator;

        [Test]
        public void CalculateLines_UnknownFile_ShouldThrowException()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Func<LineCalculator> actual = () =>
            {
                return new LineCalculator("../../../TestFiles/NotExists.smth");
            };

            actual.Should().Throw<Exception>();
        }
        
        [Test]
        public void CalculateLines_JavascriptFile_ShouldReturnCorrectResult()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            _calculator = new LineCalculator("../../../TestFiles/JavaScript.js");
            var actual = _calculator.CalculateLines();
            
            var expected = new CalculationResult
            {
                CodeLines = 3,
                CommentLines = 8,
                HybridLines = 2,
                EmptyLines = 2
            };

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void CalculateLines_CSharpFile_ShouldReturnCorrectResult()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            _calculator = new LineCalculator("../../../TestFiles/CSharp.cs");
            var actual = _calculator.CalculateLines();
            
            var expected = new CalculationResult
            {
                CodeLines = 5,
                CommentLines = 5,
                HybridLines = 3,
                EmptyLines = 3
            };

            expected.Should().BeEquivalentTo(actual);
        }
        
        [Test]
        public void CalculateLines_PythonFile_ShouldReturnCorrectResult()
        {
            var a = Directory.GetCurrentDirectory();
            
            Console.WriteLine(Directory.GetCurrentDirectory());
            _calculator = new LineCalculator("../../../TestFiles/Python.py");
            var actual = _calculator.CalculateLines();
            
            var expected = new CalculationResult
            {
                CodeLines = 3,
                CommentLines = 4,
                HybridLines = 1,
                EmptyLines = 3
            };

            expected.Should().BeEquivalentTo(actual);
        }
    }
}