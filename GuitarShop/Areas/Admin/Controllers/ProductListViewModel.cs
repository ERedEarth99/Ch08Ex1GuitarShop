using GuitarShop.Models;
using System.Collections.Generic;

namespace GuitarShop.Areas.Admin.Controllers
{
    internal class ProductListViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public string SelectedCategory { get; set; }
    }
}