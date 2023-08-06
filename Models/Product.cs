namespace BackEnd.SuperMarket.Models
{
    public class Product
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public decimal Price {get; set;}
        public int CategoryId {get;set;}
        public Category? Category{get; set;}
        public ProductSuper? ProductSupers { get;  set; }
    }

    public class ProductTest
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public decimal Price {get; set;}
        public decimal Quantity {get; set;}
        public decimal PricePartial {get; set;}
    }
}