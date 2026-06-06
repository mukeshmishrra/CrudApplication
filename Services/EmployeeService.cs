using CrudAppliction.Data;
using CrudAppliction.Models;
using CrudAppliction.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CrudAppliction.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeeAsync()
        {
            return await _context.Employees
              .Select(emp => new EmployeeResponseDto
              {
                  EmpId = emp.EmpId,
                  EmpFirstname = emp.EmpFirstname,
                  EmpLastname = emp.EmpLastname,
                  EmpEmail = emp.EmpEmail,
                  EmpLocation = emp.EmpLocation,
                  EmpSalary = emp.EmpSalary,
              }).ToListAsync<EmployeeResponseDto>();
        }

        public async Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int id)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(e => e.EmpId == id);
            if (emp == null) return null;

            return new EmployeeResponseDto
            {

                EmpId = emp.EmpId,
                EmpFirstname = emp.EmpFirstname,
                EmpLastname = emp.EmpLastname,
                EmpEmail = emp.EmpEmail,
                EmpLocation = emp.EmpLocation,
                EmpSalary = emp.EmpSalary,

            };
        }


        public async Task<EmployeeResponseDto> CreateEmployeeAsync(EmployeeCreateDto dto)
        {
            var emp = new Employee
            {
                EmpFirstname = dto.EmpFirstname,
                EmpLastname = dto.EmpLastname,
                EmpEmail = dto.EmpEmail,
                EmpLocation = dto.EmpLocation,
                EmpSalary = dto.EmpSalary,
            };
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();

            return new EmployeeResponseDto
            {
                EmpId = emp.EmpId,
                EmpFirstname = emp.EmpFirstname,
                EmpLastname = emp.EmpLastname,
                EmpEmail = emp.EmpEmail,
                EmpLocation = emp.EmpLocation,
                EmpSalary = emp.EmpSalary,
            };

        }


        public async Task<EmployeeResponseDto?> UpdateEmployeeAsync(int id, EmployeeCreateDto EmployeeUpdateRequest)
        {
            var existingEmp = await _context.Employees.FindAsync(id);
            
            if(existingEmp == null)
            {
                return null;
            }

            existingEmp.EmpFirstname = EmployeeUpdateRequest.EmpFirstname;
            existingEmp.EmpLastname = EmployeeUpdateRequest.EmpLastname;
            existingEmp.EmpEmail = EmployeeUpdateRequest.EmpEmail;
            existingEmp.EmpLocation = EmployeeUpdateRequest.EmpLocation;
            existingEmp.EmpSalary = EmployeeUpdateRequest.EmpSalary;


            await _context.SaveChangesAsync();

            return new EmployeeResponseDto
            {
                EmpId = existingEmp.EmpId,
                EmpFirstname = existingEmp.EmpFirstname,
                EmpLastname = existingEmp.EmpLastname,
                EmpEmail = existingEmp.EmpEmail,
                EmpLocation = existingEmp.EmpLocation,
                EmpSalary = existingEmp.EmpSalary,
            };
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var deleteEmp = await _context.Employees.FindAsync(id);
            if (deleteEmp == null) return false;

            _context.Employees.Remove(deleteEmp);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
