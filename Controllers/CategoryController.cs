using DocumentProject.Data;
using DocumentProject.Models;
using DocumentProject.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DocumentProject.Controllers;

public class CategoryController : Controller
{
    private ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public IActionResult Index()
    {
        var category = _db.Categories.ToList();
        return View(category);
    }

    public IActionResult Detail(string id)
    {
        int categoryId = Int32.Parse(id);
        var category = _db.Categories.Find(categoryId);
        return View(category);
    }
    
    public IActionResult Delete(string id)
    {
        int categoryId = Int32.Parse(id);
        var category = _db.Categories.Find(categoryId);
        if (category != null)
        {
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        CategoryCreate formCategory = new CategoryCreate();
        return View(formCategory);
    }
    
    [HttpPost]
    public IActionResult Create(CategoryCreate category)
    {
        Category newCategory = new Category()
        {
            CategoryName = category.CategoryName
        };
        var savedCategory = _db.Categories.Add(newCategory);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(string id)
    {
        int categoryId = Int32.Parse(id);
        var category = _db.Categories.Find(categoryId);
        CategoryUpdate newCategory = new CategoryUpdate()
        {
            Id = category.Id,
            CategoryName = category.CategoryName
        };
        return View(newCategory);
    }

    [HttpPost]
    public IActionResult Update(CategoryUpdate categoryUpdate)
    {
        var category = _db.Categories.Find(categoryUpdate.Id);
        category.Id = categoryUpdate.Id;
        category.CategoryName = categoryUpdate.CategoryName;
        _db.SaveChanges();
        string cateId = $"{categoryUpdate.Id}";
        return RedirectToAction("Detail", new { id = cateId });
    }
}