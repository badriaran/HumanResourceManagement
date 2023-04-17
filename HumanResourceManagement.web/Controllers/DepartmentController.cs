using Microsoft.AspNetCore.Mvc;
using HumanResourceManagement.ApplicationCore.Data;
using HumanResourceManagement.ApplicationCore.Models;
using HumanResourceManagement.web.ViewModels;
using HumanResourceManagement.web.Mappers;

namespace HumanResourceManagement.web.Controllers;

public class DepartmentController : Controller
{
    HumanResourceContext db = new HumanResourceContext();
    public IActionResult Index()
    {
        List<Department> departments = db.Departments.ToList();
        List<DepartmentViewModel> departmentViewModel = DepartmentMapper.MapToViewModel(departments);
        return View(departmentViewModel);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(DepartmentViewModel departmentViewModel)
    {
        var department=DepartmentMapper.MapToModel(departmentViewModel);
        if (department is null && !ModelState.IsValid)
            return Problem("To be inserted department Object is null. ");

        db.Departments.Add(department);
        db.SaveChanges();
        return RedirectToAction("Index");

    }
    [HttpGet]
    public IActionResult Details(int id)
    {
        var department = db.Departments.Find(id);
        var departmentViewModel=DepartmentMapper.MapToViewModel(department);
        return View(departmentViewModel);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var department = db.Departments.Find(id);
        var departmentViewModel = DepartmentMapper.MapToViewModel(department);
        return View(departmentViewModel);
    }
    [HttpPost]
    public IActionResult Edit(DepartmentViewModel departmentViewModel)
    {
        var department = DepartmentMapper.MapToModel(departmentViewModel);
        db.Departments.Update(department);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {

        var department = db.Departments.Find(id);
        var departmentViewModel = DepartmentMapper.MapToViewModel(department);

        return View(departmentViewModel);
    }
    [HttpPost]
    public IActionResult Delete(DepartmentViewModel departmentViewModel)
    {
        var department = DepartmentMapper.MapToModel(departmentViewModel);
        db.Departments.Remove(department);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
