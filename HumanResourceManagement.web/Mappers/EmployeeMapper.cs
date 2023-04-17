using HumanResourceManagement.web.Models;
using HumanResourceManagement.web.ViewModels;

namespace HumanResourceManagement.web.Mappers;

public class EmployeeMapper
{
    public static Employee MapToModel(EmployeeViewModel employeeViewModel) //convert employee viewmodel to employee model
    {
        var employee = new Employee
        {
            Id= employeeViewModel.Id,
            Name = employeeViewModel.Name,
            Gender = employeeViewModel.Gender,
            Address = employeeViewModel.Address,
            Dob = employeeViewModel.Dob,
            Contact = employeeViewModel.Contact,
            DepartmentId = employeeViewModel.Department,
            Designation = employeeViewModel.Designation,
            JoinedDate = employeeViewModel.JoinedDate,
            ProfileImagePath = employeeViewModel.ProfileImagePath

        };
        return employee;
    }
    public static EmployeeViewModel MapToViewModel(Employee employee)
    {
        var employeeViewModel = new EmployeeViewModel()
        {   //destination= source

            Id= employee.Id,
            Name = employee.Name,
            Gender = employee.Gender,
            Address = employee.Address,
            Dob = employee.Dob,
            Contact = employee.Contact,
            DepartmentName= employee.department?.Name??"N/A",
            Designation= employee.Designation,
            JoinedDate= employee.JoinedDate,
            ProfileImagePath= employee.ProfileImagePath
        };
        return employeeViewModel;
    }
    public static List<EmployeeViewModel> MapToViewModel(List<Employee> employees)
    {
        var employeeViewModels = employees.Select(emp => MapToViewModel(emp)).ToList();
        return employeeViewModels;
    }
}
