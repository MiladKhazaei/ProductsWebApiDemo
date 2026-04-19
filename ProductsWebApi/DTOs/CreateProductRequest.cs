namespace ProductsWebApiDemo.DTOs
{
    public class CreateProductRequest
    {
        public int Id { set; get; }
        public string? Name { get; set; }
        public int? TotalCount { get; set; }
        public int? SellCount { get; set; }

        public decimal? Price { get; set; }
    }
}
