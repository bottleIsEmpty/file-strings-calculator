using System;
using LineCalculation.Core;

namespace LineCalculation
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу с кодом:");
            var path = Console.ReadLine();
            
            var calculator = new LineCalculator(path);
            var result = calculator.CalculateLines();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Строк кода: {result.CodeLines}");
            Console.WriteLine($"Строк комментариев: {result.CommentLines}");
            Console.WriteLine($"Пустых строк: {result.EmptyLines}");
            Console.WriteLine($"Смешанных строк: {result.HybridLines}");
        }
    }
}