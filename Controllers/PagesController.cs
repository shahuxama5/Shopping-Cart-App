using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Data;
using ShoppingCartApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Controllers
{
    public class PagesController : Controller
    {
        private readonly ShoppingCartDbContext context;

        public PagesController(ShoppingCartDbContext context)
        {
            this.context = context;
        }

        // Get / Or / Slug
        public async Task<IActionResult> Page(string slug)
        {
            if (slug == null)
            {
                return View(await context.Pages.Where(x => x.Slug == "home").FirstOrDefaultAsync());
            }

            Page page = await context.Pages.Where(x => x.Slug == slug).FirstOrDefaultAsync();

            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }
    }
}
