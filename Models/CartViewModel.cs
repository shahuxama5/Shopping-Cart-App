using System.Collections.Generic;

namespace ShoppingCartApp.Models
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public decimal GrandTotal { get; set; }

    }
}
