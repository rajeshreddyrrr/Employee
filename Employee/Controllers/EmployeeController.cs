using AutoMapper;
using Employee.DTOs;
using Employee.Models;
using Employee.Repositories.Implementations;
using Employee.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return View(employeeDtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Models.Employee>(employeeDto);
                employee.CreatedDate = DateTime.Now;
                await _employeeRepository.AddEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDto);
        }

        [HttpGet]
        public async Task<IActionResult> AddSalary(int employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            var salaryDto = new EmployeeSalaryDto
            {
                Id = employeeId
            };

            ViewBag.EmployeeName = $"{employee.FirstName} {employee.LastName}";

            return View(salaryDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddSalary(EmployeeSalaryDto salaryDto)
        {
            if (ModelState.IsValid)
            {
                var salary = _mapper.Map<EmployeeSalary>(salaryDto);
                salary.CreatedDate = DateTime.Now;
                await _employeeRepository.UpdateEmployeeSalaryAsync(salary);
                return RedirectToAction(nameof(Index));
            }

            var employee = await _employeeRepository.GetEmployeeByIdAsync(salaryDto.Id);
            ViewBag.EmployeeName = $"{employee.FirstName} {employee.LastName}";

            return View(salaryDto);
        }

    }
}
