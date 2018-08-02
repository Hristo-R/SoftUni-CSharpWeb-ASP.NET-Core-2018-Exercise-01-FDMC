namespace FDMC.App.Controllers
{
    using FDMC.Data;
    using Microsoft.AspNetCore.Mvc;

    public class CatsController : Controller
    {
        public CatsController(CatContext context)
        {
            this.Context = context;
        }

        public CatContext Context { get; set; }

        public IActionResult Details(int id)
        {
            var cat = this.Context.Cats.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View();
        }
    }
}