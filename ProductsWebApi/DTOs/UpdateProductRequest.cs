namespace ProductsWebApiDemo.DTOs
{
    public class UpdateProductRequest
    {
        public int Id { set; get; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? TotalCount { get; set; }
    }
}
