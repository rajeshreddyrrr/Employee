using Employee.Data;
using Employee.Models;
using Employee.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Models.Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddEmployeeAsync(Models.Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Models.Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeSalaryAsync(EmployeeSalary salary)
        {
            _context.EmployeeSalaries.Update(salary);
            await _context.SaveChangesAsync();
        }
    }

}
