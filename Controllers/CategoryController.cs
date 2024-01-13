using csharp.DataAccess;
using csharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository catRepo;
    public CategoryController(ICategoryRepository conn)
    {
        catRepo = conn;
    }
    public IActionResult Index()
    {
        List<Category> data = catRepo.GetAll().ToList();
        return View(data);

    }

    // for Get
    public IActionResult Create()
    {
        return View();
    }

    //for post request to create category
    [HttpPost]
    public IActionResult Create(Category cat)
    {
        if (cat.Name == cat.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The name should not match the display order");
        }
        if (cat.Name != null && cat.Name.Equals("test", StringComparison.CurrentCultureIgnoreCase))
        {
            ModelState.AddModelError("Name", "test is invalid valid");
        }
        if (ModelState.IsValid)
        {
            catRepo.Insert(cat);
            catRepo.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View();
    }

    // for Get
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        // first style of retrieving data from db using GET - only works on the primary key
        Category? data = catRepo.Get(u => u.Id == id);
        // second style of retrieving data from db using GET - will work if not a primary key
        // Category? data1 = db.Categories.FirstOrDefault(u => u.Id == id);
        // last style of retrieving data from db using GET - mainly used for complex queries
        // Category? data2 = db.Categories.Where(u => u.Id == id).FirstOrDefault();
        if (data == null)
        {
            return NotFound();
        }
        return View(data);
    }

    //for post request to create category
    [HttpPost]
    public IActionResult Edit(Category cat)
    {
        if (ModelState.IsValid)
        {
            catRepo.Update(cat);
            catRepo.Save();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Category? data = catRepo.Get(u => u.Id == id);
        if (data == null)
        {
            return NotFound();
        }
        return View(data);
    }

    //for post request to create category
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        // find the category from db
        Category? data = catRepo.Get(u => u.Id == id);

        if (data == null)
        {
            return NotFound();
        }
        catRepo.Delete(data);
        catRepo.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");

    }
}