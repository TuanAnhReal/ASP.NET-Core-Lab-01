namespace Lab_01.Models
{
    public class CategoryStatisticViewModel
    {
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public double AveragePrice { get; set; }
        public double TotalValue { get; set; }
    }
}