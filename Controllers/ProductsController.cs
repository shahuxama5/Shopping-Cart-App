using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Data;
using ShoppingCartApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ShoppingCartDbContext context;

        public ProductsController(ShoppingCartDbContext context)
        {
            this.context = context;
        }

        // Get / Products
        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 6;
            var products = context.Products.OrderByDescending(x => x.Id).Skip((p - 1) * pageSize).Take(pageSize);
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Products.Count() / pageSize);
            return View(await products.ToListAsync());
        }

        // Get / Products / Category
        public async Task<IActionResult> ProductsByCategory(string categorySlug, int p = 1)
        {
            Category category = await context.Categories.Where(x => x.Slug == categorySlug).FirstOrDefaultAsync();
            if (category == null)
            {
                return RedirectToAction("Index");
            }

            int pageSize = 6;
            var products = context.Products.OrderByDescending(x => x.Id).Where(x => x.CategoryId == category.Id).Skip((p - 1) * pageSize).Take(pageSize);
           
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Products.Where(x => x.CategoryId == category.Id).Count() / pageSize);
            ViewBag.CategoryName = category.Name;
            ViewBag.CategorySlug = category.Slug;

            return View(await products.ToListAsync());
        }
    }
}
