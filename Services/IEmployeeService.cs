using CrudAppliction.Models;
using CrudAppliction.Models.Dtos;

namespace CrudAppliction.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeeAsync();

        Task<EmployeeResponseDto?>  GetEmployeeByIdAsync(int id);

        Task<EmployeeResponseDto> CreateEmployeeAsync(EmployeeCreateDto EmployeeRequest);

        Task<EmployeeResponseDto?> UpdateEmployeeAsync(int id, EmployeeCreateDto EmployeeUpdateRequest);

        Task<bool>  DeleteEmployeeAsync(int id);
    }
}
