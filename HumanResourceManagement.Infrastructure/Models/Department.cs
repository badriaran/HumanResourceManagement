using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HumanResourceManagement.ApplicationCore.Models;

public class Department
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    
    public DateTime establishedDate { get; set; }

    public List<Employee> Employees { get; set; }   
}
