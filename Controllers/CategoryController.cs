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
        return View(objCategoryList);
    }

    // for View
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

    public IActionResult Edit()
    {
        return View();
    }
}