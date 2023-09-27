using basement_learn_v1.Data;
using basement_learn_v1.Models;
using Microsoft.AspNetCore.Mvc;

namespace basement_learn_v1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController( ApplicationDbContext db )
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            
            return View(categories);
        }

        public IActionResult CreateCategory() => View();
        [HttpPost]
        public IActionResult CreateCategory( Category category)
        {
            if(category.Name.ToLower() == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Cannot same with displayOrder");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();                
                return RedirectToAction("Index");
            }
            
            return View();
        }
    }
}
