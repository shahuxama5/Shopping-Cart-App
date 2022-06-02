using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Data
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ShoppingCartDbContext context;

        public CategoriesViewComponent(ShoppingCartDbContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await GetCategoriesAsync();
            return View(categories);
        }

        private Task<List<Category>> GetCategoriesAsync()
        {
            return context.Categories.OrderBy(x => x.Sorting).ToListAsync();
        }
    }
}
