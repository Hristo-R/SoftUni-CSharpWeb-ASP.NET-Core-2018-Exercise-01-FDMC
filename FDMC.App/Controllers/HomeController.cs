namespace FDMC.App.Controllers
{
    using FDMC.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class HomeController : Controller
    {
        public HomeController(CatContext context)
        {
            this.Context = context;
        }

        public CatContext Context { get; set; }

        public IActionResult Index()
        {
            var cats = this.Context.Cats.ToArray();

            return View(model: cats);
        }
    }
}