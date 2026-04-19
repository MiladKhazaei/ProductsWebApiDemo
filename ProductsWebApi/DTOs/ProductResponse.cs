using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsWebApiDemo.DTOs
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
		[Column(TypeName = "decimal(8,2)")]
		public decimal? Price { get; set; }
		[Column(TypeName = "decimal(10,2)")]
        [DisplayName("Sell Price")]
        [Display(Name ="Sell Price")]
		public decimal? SellPrice { get; set; }
    }
}
