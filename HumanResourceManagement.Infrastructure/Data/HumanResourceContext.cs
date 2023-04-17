using HumanResourceManagement.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceManagement.ApplicationCore.Data;

public class HumanResourceContext:DbContext
{ 
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=HumanResourceMgt;Integrated Security=true");
    }
}
