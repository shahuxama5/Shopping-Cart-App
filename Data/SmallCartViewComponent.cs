using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Data
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            SmallCartViewModel smallCartVM;

            if (cart == null || cart.Count == 0)
            {
                smallCartVM = null;
            }
            else
            {
                smallCartVM = new SmallCartViewModel
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    TotalAmount = cart.Sum(x => x.Price * x.Quantity)
                };
            }

            return View(smallCartVM);
        }
    }
}
