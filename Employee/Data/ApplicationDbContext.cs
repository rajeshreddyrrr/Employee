using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Employee>()
                .HasMany(e => e.EmployeeSalaries)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.EmployeeId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
