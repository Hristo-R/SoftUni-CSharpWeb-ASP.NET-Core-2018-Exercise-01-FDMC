namespace FDMC.App.Controllers
{
    using FDMC.App.Models.BindingModels;
    using FDMC.Data;
    using FDMC.Models;
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

            var catModel = new CatCreatingBindingModel()
            {
                Name = cat.Name,
                Age = cat.Age,
                Breed = cat.Breed,
                ImageUrl = cat.ImageUrl
            };
            return View(catModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Cat model)
        {
            this.Context.Cats.Add(model);
            this.Context.SaveChanges();

            return RedirectToAction("Details", new { id = model.Id });
        }
    }
}