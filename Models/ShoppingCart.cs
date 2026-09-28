namespace CologneWorld.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(CartItem newItem)
        {
            var existingItem = Items.FirstOrDefault(item => item.ProductId == newItem.ProductId);
            if (existingItem != null)
                existingItem.Quantity += newItem.Quantity;
            else
                Items.Add(newItem);
        }

        public void RemoveItem(int productId)
        {
            Items.RemoveAll(item => item.ProductId == productId);
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null) item.Quantity = quantity;
        }

        public decimal GetGrandTotal() => Items.Sum(item => item.Subtotal);
        public void ClearCart() => Items.Clear();
        public int GetTotalItems() => Items.Sum(item => item.Quantity);
    }
}