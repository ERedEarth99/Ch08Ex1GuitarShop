using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GuitarShop.Models;

namespace GuitarShop.Controllers
{
    public class ProductController : Controller
    {
        private ShopContext context;

        public ProductController(ShopContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }
        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            // Fetch categories and products
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();

            var products = id == "All"
                ? context.Products
                    .OrderBy(p => p.ProductID).ToList()
                : context.Products
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.ProductID).ToList();

            // Create and populate the ProductViewModel for question 6
            var model = new ProductViewModel
            {
                Categories = categories,
                Products = products,
                SelectedCategory = id
            };

            // Pass the view model to the view for question 7
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();

            Product product = context.Products.Find(id);

            string imageFilename = product.Code + "_m.png";

            // use ViewBag to pass data to view
            ViewBag.Categories = categories;
            ViewBag.ImageFilename = imageFilename;

            // bind product to view
            return View(product);
        }
    }
}