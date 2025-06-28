namespace BlazorNgani.Models
{
    public class Product

    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Language { get; set; }
        public ProductStatus Status { get; set; }
        public string CoverImagePath { get; set; }
        public string Category { get; set; }
        public string Genre { get; set; }
        public string Tags { get; set; }
        public int StockCount { get; set; }

    }



    public enum ProductStatus
    {
        Active,
        Inactive,
        ComingSoon,
        Archived
    }
}
