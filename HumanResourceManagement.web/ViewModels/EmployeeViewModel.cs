using HumanResourceManagement.web.Enums;
using HumanResourceManagement.web.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HumanResourceManagement.web.ViewModels;

public class EmployeeViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Enter Your Name"), MinLength(2, ErrorMessage = "Name should contain atleast length of 2")]
    public string Name { get; set; } = string.Empty;
    public Sex Gender { get; set; } = Sex.Male;
    public string? Address { get; set; }
    [DisplayName("Date of birth")]
    [DataType(DataType.Date)]
    public DateTime Dob { get; set; }
    public string Contact { get; set; } = string.Empty;
    [DataType(DataType.Date)]
    public DateTime JoinedDate { get; set; }
    public string Department { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;

  
    [DisplayName("Your Profile Image")]
    public IFormFile? ProfileImage { get; set; }
    public string ProfileImagePath { get; set; } = string.Empty;

    //connecting two tables
    public int? DepartmentId { get; set; }

    public Department department { get; set; }

}
