using CologneWorld.Models;

namespace CologneWorld.Services
{
    public class ProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Versace Eros EDP 100ml",
                    Description = "Luxury fragrance with mint and vanilla notes",
                    Category = "Premium Cologne",
                    UnitPrice = 9600.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1592945403244-b3fbafd7f539?w=500&h=500&fit=crop"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Chanel Bleu de Chanel 100ml",
                    Description = "Sophisticated scent with citrus and woody notes",
                    Category = "Luxury Cologne",
                    UnitPrice = 10000.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1544441893-675973e31985?w=500&h=500&fit=crop"
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Armani Acqua di Gio 100ml",
                    Description = "Elegant fragrance with floral and musk notes",
                    Category = "Designer Cologne",
                    UnitPrice = 15000.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1590736969955-1d0c72c72b97?w=500&h=500&fit=crop"
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Dior Sauvage EDT 100ml",
                    Description = "Fresh and spicy aromatic fragrance for the modern man",
                    Category = "Premium Cologne",
                    UnitPrice = 12000.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1595428774223-ef52624120d2?w=500&h=500&fit=crop"
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Tom Ford Noir 100ml",
                    Description = "Dark and mysterious oriental scent for evening wear",
                    Category = "Luxury Cologne",
                    UnitPrice = 18000.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1595263182118-71f34d258cbb?w=500&h=500&fit=crop"
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Prada Luna Rossa 100ml",
                    Description = "Fresh lavender and bitter orange with a modern twist",
                    Category = "Sport Cologne",
                    UnitPrice = 11000.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1615634260167-46a2c6f89ab5?w=500&h=500&fit=crop"
                },
                new Product
                {
                    ProductId = 7,
                    Name = "Gucci Guilty 100ml",
                    Description = "Provocative and addictive floral fragrance",
                    Category = "Designer Cologne",
                    UnitPrice = 9500.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1610998342126-c18f37190a0c?w=500&h=500&fit=crop"
                },
                new Product
                {
                    ProductId = 8,
                    Name = "Yves Saint Laurent Y EDP 100ml",
                    Description = "Timeless woody aromatic fragrance with citrus notes",
                    Category = "Signature Cologne",
                    UnitPrice = 14000.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1610998342126-c18f37190a0c?w=500&h=500&fit=crop"
                },
                new Product
                {
                    ProductId = 9,
                    Name = "Creed Aventus 100ml",
                    Description = "Legendary fragrance with pineapple and birch notes",
                    Category = "Ultra Premium",
                    UnitPrice = 25000.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1592945403244-b3fbafd7f539?w=500&h=500&fit=crop"
                },
                new Product
                {
                    ProductId = 10,
                    Name = "Jean Paul Gaultier Le Male 125ml",
                    Description = "Iconic masculine scent with mint and vanilla",
                    Category = "Classic Cologne",
                    UnitPrice = 8500.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1544441893-675973e31985?w=500&h=500&fit=crop"
                },
                new Product
                {
                    ProductId = 11,
                    Name = "Dolce & Gabbana Light Blue 100ml",
                    Description = "Fresh Mediterranean-inspired citrus fragrance",
                    Category = "Summer Cologne",
                    UnitPrice = 9200.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1590736969955-1d0c72c72b97?w=500&h=500&fit=crop"
                },
                new Product
                {
                    ProductId = 12,
                    Name = "Viktor & Rolf Spicebomb 90ml",
                    Description = "Explosive blend of spices and tobacco",
                    Category = "Winter Cologne",
                    UnitPrice = 13500.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1595428774223-ef52624120d2?w=500&h=500&fit=crop"
                }
            };
        }

        public Product GetProductById(int id)
        {
            return GetProducts().FirstOrDefault(p => p.ProductId == id) ?? new Product();
        }
    }
}