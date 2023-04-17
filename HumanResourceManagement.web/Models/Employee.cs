using HumanResourceManagement.web.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResourceManagement.web.Models;

public class Employee
{
    public int Id { get; set; }
   
    public string Name { get; set; }=string.Empty;
    public Sex Gender { get; set; } = Sex.Male;
    public string? Address { get; set; }
   
    public DateTime Dob { get; set; }
    public string Contact { get; set; } = string.Empty;
    
    public DateTime JoinedDate { get; set; }
    public string Designation { get; set; }=string.Empty;
    public string ProfileImagePath { get; set; } = string.Empty;    

    //connecting two tables
    public int? DepartmentId { get; set; }

    public Department department { get; set; }


}
