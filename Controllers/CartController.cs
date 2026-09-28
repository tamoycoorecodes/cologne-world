using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using CologneWorld.Models;
using CologneWorld.Services;

namespace CologneWorld.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductService _productService;

        public CartController(ProductService productService)
        {
            _productService = productService;
        }

        // SIMPLE CART METHODS
        private ShoppingCart GetCart()
        {
            var cartJson = HttpContext.Session.GetString("ShoppingCart");
            if (string.IsNullOrEmpty(cartJson))
            {
                return new ShoppingCart();
            }

            try
            {
                return JsonSerializer.Deserialize<ShoppingCart>(cartJson) ?? new ShoppingCart();
            }
            catch
            {
                return new ShoppingCart();
            }
        }

        private void SaveCart(ShoppingCart cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString("ShoppingCart", cartJson);
            HttpContext.Session.SetInt32("CartItemCount", cart.GetTotalItems());
        }

        // SIMPLE ADD TO CART - This will work
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            // Get the product
            var product = _productService.GetProductById(productId);

            if (product == null || product.ProductId == 0)
            {
                TempData["ErrorMessage"] = "Product not found!";
                return RedirectToAction("Index", "Products");
            }

            // Get current cart
            var cart = GetCart();

            // Add the item
            cart.AddItem(new CartItem
            {
                ProductId = product.ProductId,
                ProductName = product.Name,
                Price = product.UnitPrice,
                Quantity = quantity
            });

            // Save cart
            SaveCart(cart);

            // Success message
            TempData["SuccessMessage"] = $"✅ {product.Name} added to cart!";

            return RedirectToAction("Index", "Products");
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCart();
            cart.RemoveItem(productId);
            SaveCart(cart);

            TempData["SuccessMessage"] = "Item removed from cart.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            var cart = GetCart();
            cart.UpdateQuantity(productId, quantity);
            SaveCart(cart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            var cart = GetCart();
            cart.ClearCart();
            SaveCart(cart);

            TempData["SuccessMessage"] = "Cart cleared!";
            return RedirectToAction("Index");
        }
    }
}