using Microsoft.AspNetCore.Mvc;
using HumanResourceManagement.web.Data;
using HumanResourceManagement.web.Models;

namespace HumanResourceManagement.web.Controllers;

public class DepartmentController : Controller
{
    HumanResourceContext db = new HumanResourceContext();
    public IActionResult Index()
    {
        List<Department> departments = db.Departments.ToList();
        return View(departments);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Department department)
    {
        db.Departments.Add(department);
        db.SaveChanges();
        return RedirectToAction("Index");

    }

    public IActionResult Details(int id)
    {
        var department = db.Departments.Find(id);
        return View(department);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var department = db.Departments.Find(id);
        return View(department);
    }
    [HttpPost]
    public IActionResult Edit(Department department)
    {
        db.Departments.Update(department);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Delete(int id)
    {
        var department = db.Departments.Find(id);

        return View(department);
    }
    [HttpPost]
    public IActionResult Delete(Department department)
    {
        db.Departments.Remove(department);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
