using Laborotorna8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Laborotorna8.Controllers
{
    public class FileController : Controller
    {
        private List<ProductModel> CreatedProducts()
        {
            return new List<ProductModel>() {
                new ProductModel(0, "Product1", 4500), 
                new ProductModel(1, "Product2", 7000),
                new ProductModel(2, "Product3", 8000),
                new ProductModel(3, "Product4", 1000)};
        }
        public IActionResult ReadItems()
        {
            List<ProductModel> products = CreatedProducts();
            return View(products);
        }
    }
}
