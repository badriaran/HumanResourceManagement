using HumanResourceManagement.web.Data;
using HumanResourceManagement.web.Enums;
using HumanResourceManagement.web.Helpers;
using HumanResourceManagement.web.Mappers;
using HumanResourceManagement.web.Models;
using HumanResourceManagement.web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace HumanResourceManagement.web.Controllers;

public class EmployeeController : Controller
{
    HumanResourceContext db = new HumanResourceContext();


    public IActionResult Index()
    {
       List<Employee> employees = db.Employees.ToList();

        List<EmployeeViewModel> employeeViewModels = employees.Select(x => new EmployeeViewModel()
        {
            Address = x.Address,
            Name = x.Name,
            Contact=x.Contact,
            department=x.department,
            Designation=x.Designation


        }).ToList();

        return View(employeeViewModels);
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
        return View(employee);
    }
    [HttpPost]
    public IActionResult Edit(EmployeeViewModel employeeViewModel)
    {
        var relativePath = employeeViewModel.ProfileImage?.SaveImage();
        employeeViewModel.ProfileImagePath = relativePath;
        var employee = new Employee
        {
            Name = employeeViewModel.Name,
            Gender = employeeViewModel.Gender,
            Address = employeeViewModel.Address,
            Dob = employeeViewModel.Dob,
            Contact = employeeViewModel.Contact,
            department = employeeViewModel.department,
            Designation = employeeViewModel.Designation,
            JoinedDate = employeeViewModel.JoinedDate,
            ProfileImagePath = employeeViewModel.ProfileImagePath

        };
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
