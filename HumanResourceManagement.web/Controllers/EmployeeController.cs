using HumanResourceManagement.web.Data;
using HumanResourceManagement.web.Enums;
using HumanResourceManagement.web.Helpers;
using HumanResourceManagement.web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace HumanResourceManagement.web.Controllers;

public class EmployeeController : Controller
{
    HumanResourceContext db = new HumanResourceContext();


    public IActionResult Index()
    {
        List<Employee> employees = db.Employees.ToList();

        return View(employees);
    }
    public IActionResult Details(int id)
    {
        var employee = db.Employees.Find(id);
        return View(employee);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Employee employee)
    {
        var relativePath = ProfileImageHelper.SaveImage(employee.ProfileImage);
        employee.ProfileImagePath= relativePath;

        
        db.Employees.Add(employee);
        db.SaveChanges();

        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var employee = db.Employees.Find(id);
        return View(employee);
    }
    [HttpPost]
    public IActionResult Edit(Employee employee)
    {

        db.Employees.Update(employee);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var employee = db.Employees.Find(id);
        return View(employee);
    }
    [HttpPost]
    public IActionResult Delete(Employee employee)
    {
        db.Employees.Remove(employee);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
