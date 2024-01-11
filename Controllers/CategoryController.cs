using csharp.app;
using csharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp.Controllers;

public class CategoryController : Controller
{
    private readonly Config db;
    public CategoryController(Config conn)
    {
        db = conn;
    }
    public IActionResult Index()
    {
        List<Category> objCategoryList = db.Categories.ToList();

        if (objCategoryList == null)
        {
            return View();
        }
        else
        {
            return View(objCategoryList);
        }

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
            db.Categories.Add(cat);
            db.SaveChanges();
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
        Category? data = db.Categories.Find(id);
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
            db.Categories.Add(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }
}