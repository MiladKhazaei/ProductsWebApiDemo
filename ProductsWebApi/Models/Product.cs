using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsWebApiDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? TotalCount { get; set; }
        public int? SellCount { get; set; }
        // Read-only properties
        public int? RemainingCount => TotalCount - SellCount;
        public decimal? SellPrice => SellCount * Price;
        public decimal? Price { get; set; }
    }
}
