using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Data;
using ShoppingCartApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Controllers
{
    public class CartController : Controller
    {

        private readonly ShoppingCartDbContext context;

        public CartController(ShoppingCartDbContext context)
        {
            this.context = context;
        }

        // Get / Cart
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)
            };

            return View(cartVM);
        }

        // Get / Cart / Add / 5
        public async Task<IActionResult> Add(int id)
        {
            Product product = await context.Products.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
            {
                return RedirectToAction("Index");
            }

            return ViewComponent("SmallCart");

        }

        // Get / Cart / Decrease / 5
        public IActionResult Decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(x => x.ProductId == id);
            }


            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            return RedirectToAction("Index");

        }

        // Get / Cart / Remove / 5
        public IActionResult Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(x => x.ProductId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            return RedirectToAction("Index");

        }

        // Get / Cart / Clear
        public IActionResult Clear()
        {         
             HttpContext.Session.Remove("Cart");

            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
            {
                return Redirect(Request.Headers["Referer"].ToString());
                //return Redirect("/");
                // return RedirectToAction("Page", "Pages");
            }

            return Ok();
                
            
        }

    }
}
