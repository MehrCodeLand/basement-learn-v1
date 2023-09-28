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


        public IActionResult EditCategory( int? id )
        {
            if (id == null || id < 0 )
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory( Category category)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteCategory( int? id )
        {
            if(id == null || id < 0 )
            {
                return NotFound();
            }
            var category = _db.Categories.Find( id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            _db.Categories.Remove(category);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
