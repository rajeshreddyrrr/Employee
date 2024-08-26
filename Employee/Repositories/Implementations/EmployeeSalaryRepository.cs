using Employee.Data;
using Employee.Models;
using Employee.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repositories.Implementations
{
    public class EmployeeSalaryRepository : IEmployeeSalaryRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeSalaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeSalary>> GetSalariesByEmployeeIdAsync(int employeeId)
        {
            return await _context.EmployeeSalaries
                .Where(s => s.EmployeeId == employeeId && s.SalaryDate.Year == DateTime.Now.Year)
                .ToListAsync();
        }

        public async Task AddEmployeeSalaryAsync(EmployeeSalary salary)
        {
            await _context.EmployeeSalaries.AddAsync(salary);
            await _context.SaveChangesAsync();
        }
    }
}
