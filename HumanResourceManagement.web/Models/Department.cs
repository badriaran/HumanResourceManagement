using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HumanResourceManagement.web.Models;

public class Department
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Please Enter Department Name"), DisplayName("Department Name")]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    [DataType(DataType.Date), DisplayName("Established Date")]
    public DateTime establishedDate { get; set; }

    public List<Employee> Employees { get; set; }   
}
