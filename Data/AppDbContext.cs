using CrudAppliction.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAppliction.Data
{
    // Inheriting from DbContext gives us all Entity Framework functionalities
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        // This represents your actual table. The table in SQL will be named "Products"
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Employee> Employees => Set<Employee>();

    }
}
