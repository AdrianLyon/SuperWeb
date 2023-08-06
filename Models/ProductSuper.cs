using System.Collections.Generic;

namespace BackEnd.SuperMarket.Models
{
    public class ProductSuper
    {
        public int Id {get; set;}
        public string Description {get; set;} = string.Empty;
        public decimal Price {get; set;}
        public decimal Quantity {get; set;}
        public decimal PricePartial {get; set;}

        public int ProductId {get; set;}
        public ICollection<Product> Products{get; set;} = new List<Product>();
    }
}