using Bulkybook.Data;
using Bulkybook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bulkybook.Controllers
{
    public class CategoryController : Controller
    {
        // here I initialize an object (_db) where I store all the data from database table.
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string searchString)
        {
            ViewData["filterStudent"] = searchString;

            var query = _db.Categories.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
                query = query.Where(x => x.Name.Contains(searchString));

            return View(query.ToList());
            

        }

        // GET
        // Here I am giving the form to the user for create a new Category
        public IActionResult Create()
        {
            // I Create view I give a form
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Here I am colleting all the data which user give into the form and I will store them into databsase
        public IActionResult Create(Category obj) // here colleting data by using Category parameter obj
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom Error", "Display Order shouldn't exactly match with Name");
            }
            if(ModelState.IsValid) // Here I am checking the validation, that means required fill or others
            {
                // here I am adding the value to database
                _db.Categories.Add(obj);
                _db.SaveChanges(); // Now data will be save into database
                return RedirectToAction("Index");
            }
            return View(obj);
           
        }


        // GET
        // Here I am giving the form to the user for udate Category
        public IActionResult Update(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            var categoryFromDb = _db.Categories.Find(id);

            if(categoryFromDb==null)
            {
                return NotFound();
            }
            // I Create view I give a form
            return View(categoryFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Here I am collet the data from database then I will update the data and I will restore them into databsase
        public IActionResult Update(Category obj) // here colleting data by using Category parameter obj
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom Error", "Display Order shouldn't exactly match with Name");
            }
            if (ModelState.IsValid) // Here I am checking the validation, that means required fill or others
            {
                // here I am adding the value to database
                _db.Categories.Update(obj);
                _db.SaveChanges(); // Now data will be save into database
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        // GET
        // Here I am giving the form to the user for Delete Category
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            // I Create view I give a form
            return View(categoryFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Here I am colleting all the data which user give into the form and I will store them into databsase
        public IActionResult DeletePost(int? id) // here colleting data by using Category parameter obj
        {
            var obj = _db.Categories.Find(id);
          
            if(obj == null)
            {
                return NotFound();
            }
           
            // here I am adding the value to database
            _db.Categories.Remove(obj);
            _db.SaveChanges(); // Now data will be save into database
            return RedirectToAction("Index");
        }
    }
}
