using HumanResourceManagement.ApplicationCore.Models;
using HumanResourceManagement.web.ViewModels;

namespace HumanResourceManagement.web.Mappers;

public class DepartmentMapper
{
    public static Department MapToModel(DepartmentViewModel departmentViewModel)
    {
        var department = new Department
        {
            Name = departmentViewModel.Name,
            Description = departmentViewModel.Description,
            establishedDate=departmentViewModel.establishedDate,
            Id = departmentViewModel.Id,
            Employees = departmentViewModel.Employees,

        };
        return department;
             
    }
    public static DepartmentViewModel MapToViewModel(Department department)
    {
        var departmentViewModel = new DepartmentViewModel
        {
            Name = department.Name,
            Description = department.Description,
            establishedDate = department.establishedDate,
            Id = department.Id,
            Employees = department.Employees
        };
        return departmentViewModel;
    }

    public static List<DepartmentViewModel> MapToViewModel(List<Department> departments)
    {
        var departmentViewModel= departments.Select(dep=>MapToViewModel(dep)).ToList(); 
        return departmentViewModel;
    }

}
