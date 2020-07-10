namespace LineCalculation.Core.Models
{
    public class CalculationResult
    {
        public int EmptyLines { get; set; }
        public int CodeLines { get; set; }
        public int CommentLines { get; set; }
        public int HybridLines { get; set; }
    }
}