using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Data;
using ShoppingCartApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly ShoppingCartDbContext context;

        public PagesController(ShoppingCartDbContext context)
        {
            this.context = context;
        }

        // Get / Admin / Pages 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in context.Pages orderby p.Sorting select p;

            List<Page> pagesList = await pages.ToListAsync();

            return View(pagesList);
        }

        // Get / Admin / Pages / Details / 5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Page page = await context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // Get / Admin / Pages / Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Post / Admin / Pages / Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var slug = await context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The page already exists.");
                    return View(page);
                }

                context.Add(page);
                await context.SaveChangesAsync();
                TempData["Success"] = "The page has been added!";
                return RedirectToAction("Index");

            }
            return View(page);
        }

        // Get / Admin / Pages / Edit / 5
        public async Task<IActionResult> Edit(int id)
        {
            Page page = await context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // Post / Admin / Pages / Edit / 5
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Id == 1 ? "home" : page.Title.ToLower().Replace(" ", "-");

                var slug = await context.Pages.Where(x => x.Id != page.Id).FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The page already exists.");
                    return View(page);
                }

                context.Update(page);
                await context.SaveChangesAsync();
                TempData["Success"] = "The page has been edited!";
                return RedirectToAction("Edit", new { id = page.Id });

            }
            return View(page);
        }

        // Get / Admin / Pages / Delete / 5
        public async Task<IActionResult> Delete(int id)
        {
            Page page = await context.Pages.FindAsync(id);
            if (page == null)
            {
                TempData["Error"] = "The page does not exist!";
            }
            else
            {
                context.Pages.Remove(page);
                await context.SaveChangesAsync();
                TempData["Success"] = "The page has been deleted!";
            }

            return RedirectToAction("Index");
        }

        // Post / Admin / Pages / Reorder 
        [HttpPost]
        public async Task<IActionResult> Reorder(int[] id)
        {
            int count = 1;

            foreach (var pageId in id)
            {
                Page page = await context.Pages.FindAsync(pageId);
                page.Sorting = count;
                context.Update(page);
                await context.SaveChangesAsync();
                count++;
            }

            return Ok();
        }
    }
}
