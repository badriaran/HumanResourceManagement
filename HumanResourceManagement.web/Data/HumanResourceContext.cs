using HumanResourceManagement.web.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceManagement.web.Data;

public class HumanResourceContext:DbContext
{ 
    public DbSet<Employee> Employees { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=HumanResourceMgt;Integrated Security=true");
    }
}
