using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Category = "Electronics",
                Price = 55000,
                Description = "HP Laptop with good performance"
            },

            new Product
            {
                Id = 2,
                Name = "Mobile",
                Category = "Electronics",
                Price = 25000,
                Description = "Smartphone with modern features"
            },

            new Product
            {
                Id = 3,
                Name = "Headphones",
                Category = "Accessories",
                Price = 2000,
                Description = "Wireless Headphones with clear sound"
            }
        };

        public ActionResult Index()
        {
            return View(products);
        }

        public ActionResult Details(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        public ActionResult AddToCart(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                List<Product> cart = Session["Cart"] as List<Product>;

                if (cart == null)
                {
                    cart = new List<Product>();
                }

                cart.Add(product);
                Session["Cart"] = cart;
            }

            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            List<Product> cart = Session["Cart"] as List<Product>;

            if (cart == null)
            {
                cart = new List<Product>();
            }

            return View(cart);
        }
    }
}