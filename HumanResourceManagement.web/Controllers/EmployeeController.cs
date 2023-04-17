using HumanResourceManagement.web.Data;
using HumanResourceManagement.web.Enums;
using HumanResourceManagement.web.Helpers;
using HumanResourceManagement.web.Mappers;
using HumanResourceManagement.web.Models;
using HumanResourceManagement.web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace HumanResourceManagement.web.Controllers;

public class EmployeeController : Controller
{
    HumanResourceContext db = new HumanResourceContext();


    public IActionResult Index()
    {
       List<Employee> employees = db.Employees.ToList();
        List<EmployeeViewModel> employeeViewModels = EmployeeMapper.MapToViewModel(employees);

        return View(employeeViewModels);
    }
    public IActionResult Details(int id)
    {
        var employee = db.Employees.Find(id);
        var employeeViewModel= EmployeeMapper.MapToViewModel(employee);
        return View(employeeViewModel);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var departments= db.Departments.ToList();
        var depSelectList= departments.Select(x=> new SelectListItem { Text=x.Name, Value=x.Id.ToString() }).ToList();
        depSelectList.Add(new SelectListItem { Text = "--Select Department--", Selected = true });
        ViewData["deps"] = depSelectList;
        return View();
    }

    [HttpPost]
    public IActionResult Add(EmployeeViewModel employeeViewModel)
    {
        var relativePath = employeeViewModel.ProfileImage?.SaveImage();

        var employee = EmployeeMapper.MapToModel(employeeViewModel);
        employee.ProfileImagePath= relativePath;

        
        db.Employees.Add(employee);
        db.SaveChanges();

        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var employee = db.Employees.Find(id);
        var employeeViewModel=EmployeeMapper.MapToViewModel(employee);
        return View(employeeViewModel);
    }
    [HttpPost]
    public IActionResult Edit(EmployeeViewModel employeeViewModel)
    {
        var relativePath = employeeViewModel.ProfileImage?.SaveImage();
        
        var employee = EmployeeMapper.MapToModel(employeeViewModel);
        employee.ProfileImagePath = relativePath;
        db.Employees.Update(employee);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var employee = db.Employees.Find(id);
        var employeeViewModel= EmployeeMapper.MapToViewModel(employee);
        return View(employeeViewModel);
    }
    [HttpPost]
    public IActionResult Delete(EmployeeViewModel employeeViewModel)
    {
        var employee= EmployeeMapper.MapToModel(employeeViewModel);
        db.Employees.Remove(employee);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
