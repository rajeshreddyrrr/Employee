using Employee.Models;

namespace Employee.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Models.Employee>> GetAllEmployeesAsync();
        Task<Models.Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Models.Employee employee);
        Task UpdateEmployeeAsync(Models.Employee employee);
        Task UpdateEmployeeSalaryAsync(EmployeeSalary salary);
    }
}
