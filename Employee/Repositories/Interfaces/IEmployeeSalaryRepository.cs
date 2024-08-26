using Employee.Models;

namespace Employee.Repositories.Interfaces
{
    public interface IEmployeeSalaryRepository
    {
        Task<IEnumerable<EmployeeSalary>> GetSalariesByEmployeeIdAsync(int employeeId);
        Task AddEmployeeSalaryAsync(EmployeeSalary salary);
    }
}
