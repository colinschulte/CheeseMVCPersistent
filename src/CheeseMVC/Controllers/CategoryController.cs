using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            IList<CheeseCategory> categoryList = context.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = addCategoryViewModel.Name,
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }
    }
}
