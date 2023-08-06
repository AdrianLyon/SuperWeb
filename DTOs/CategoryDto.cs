namespace BackEnd.SuperMarket.DTOs
{
    public class CategoryDto
    {
        public int Id {get; set;}
        public string Name {get; set;} 
    }

    public class CategoryAddDto
    {
        public string Name {get; set;} 
    }

    public class ProductDto
    {
        // public int Id {get; set;}
        // public string Name {get; set;} = string.Empty;
        // public decimal Price {get; set;}
        // public int CategoryId {get;set;}
        // public CategoryDto? Category{get; set;}
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal PricePartial { get; set; }
    }

    public class ProductAddDto
    {
        // public int Id {get; set;}
        // public string Name {get; set;} = string.Empty;
        // public decimal Price {get; set;}
        // public int CategoryId {get;set;}

        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }

    public class ProductUpdateDto
    {
        // public int Id {get; set;}
        // public string Name {get; set;} = string.Empty;
        // public decimal Price {get; set;}
        // public int CategoryId {get;set;}

        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}