using Microsoft.AspNetCore.Mvc;
using CologneWorld.Services;

namespace CologneWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            // Get first 3 products with guaranteed images
            var featuredProducts = _productService.GetProducts()
                .Take(3)
                .Select(p => new CologneWorld.Models.Product
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Category = p.Category,
                    UnitPrice = p.UnitPrice,
                    ImageUrl = string.IsNullOrEmpty(p.ImageUrl)
                        ? "https://images.unsplash.com/photo-1592945403244-b3fbafd7f539?w=400&h=400&fit=crop"
                        : p.ImageUrl
                })
                .ToList();

            return View(featuredProducts);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}