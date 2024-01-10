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
    public IActionResult Index(){
        List<Category> objCategoryList = db.Categories.ToList();
        return View(objCategoryList);
    }
}