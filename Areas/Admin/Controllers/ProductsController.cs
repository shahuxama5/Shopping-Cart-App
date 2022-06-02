using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Data;
using ShoppingCartApp.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ShoppingCartDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductsController(ShoppingCartDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // Get / Admin / Products
        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 6;
            var products = context.Products.OrderByDescending(x => x.Id).Include(x => x.Category).Skip((p - 1) * pageSize).Take(pageSize);
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Products.Count()/pageSize);
            return View(await products.ToListAsync());
        }

        // Get / Admin / Products / Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(context.Categories.OrderBy(x => x.Sorting), "Id", "Name");
            return View();
        }

        // Post / Admin / Products / Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.CategoryId = new SelectList(context.Categories.OrderBy(x => x.Sorting), "Id", "Name");

            if (ModelState.IsValid)
            {
                product.Slug = product.Name.ToLower().Replace(" ", "-");

                var slug = await context.Products.FirstOrDefaultAsync(x => x.Slug == product.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The product already exists.");
                    return View(product);
                }

                string imageName = "noimage.png";
                if (product.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "media/products");
                    imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    product.Image = imageName;
                }


                context.Add(product);
                await context.SaveChangesAsync();
                TempData["Success"] = "The product has been added!";
                return RedirectToAction("Index");

            }
            return View(product);
        }

        // Get / Admin / Products / Details / 5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Product product = await context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Get / Admin / Products / Edit / 5
        public async Task<IActionResult> Edit(int id)
        {
            Product product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.CategoryId = new SelectList(context.Categories.OrderBy(x => x.Sorting), "Id", "Name", product.CategoryId);

            return View(product);
        }

        // Post / Admin / Products / Edit / 5
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            ViewBag.CategoryId = new SelectList(context.Categories.OrderBy(x => x.Sorting), "Id", "Name", product.CategoryId);

            if (ModelState.IsValid)
            {
                product.Slug = product.Name.ToLower().Replace(" ", "-");

                var slug = await context.Products.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Slug == product.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The product already exists.");
                    return View(product);
                }

                if (product.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "media/products");

                    if (!string.Equals(product.Image, "noimage.png"))
                    {
                        string oldImagePath = Path.Combine(uploadDir, product.Image);

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    product.Image = imageName;
                }


                context.Update(product);
                await context.SaveChangesAsync();
                TempData["Success"] = "The product has been edited!";
                return RedirectToAction("Index");

            }
            return View(product);
        }

        // Get / Admin / Products / Delete / 5
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await context.Products.FindAsync(id);
            if (product == null)
            {
                TempData["Error"] = "The product does not exist!";
            }
            else
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "media/products");

                if (!string.Equals(product.Image, "noimage.png"))
                {
                    string oldImagePath = Path.Combine(uploadDir, product.Image);

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                context.Products.Remove(product);
                await context.SaveChangesAsync();
                TempData["Success"] = "The product has been deleted!";
            }

            return RedirectToAction("Index");
        }

        // Post / Admin / Category / Reorder 
        [HttpPost]
        public async Task<IActionResult> Reorder(int[] id)
        {
            int count = 1;

            foreach (var categoryId in id)
            {
                Category category = await context.Categories.FindAsync(categoryId);
                category.Sorting = count;
                context.Update(category);
                await context.SaveChangesAsync();
                count++;
            }

            return Ok();
        }
    }
}
