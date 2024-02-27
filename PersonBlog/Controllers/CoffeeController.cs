using Microsoft.AspNetCore.Mvc;
using PersonBlog.Models;

namespace PersonBlog.Controllers
{
    public class CoffeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(string name)
        {
            var coffees = GetCoffees();
            var coffee = coffees.FirstOrDefault(c => c.Name == name);
            return View(coffee);
        }

        private List<Coffee> GetCoffees()
        {
            return new List<Coffee>
        {
            new Coffee { Name = "Espresso", ImagePath = "/images/espresso.jpg" },
            new Coffee { Name = "Latte", ImagePath = "/images/latte.jpg" },
            new Coffee { Name = "Cappuccino", ImagePath = "/images/cappuccino.jpg" }
            // Diğer kahveler buraya eklenebilir
        };
        }
    }
}
