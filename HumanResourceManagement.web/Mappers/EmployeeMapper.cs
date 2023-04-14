using HumanResourceManagement.web.Models;
using HumanResourceManagement.web.ViewModels;

namespace HumanResourceManagement.web.Mappers;

public class EmployeeMapper
{
    public static Employee MapToModel(EmployeeViewModel employeeViewModel)
    {
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
        return employee;
    }
}
