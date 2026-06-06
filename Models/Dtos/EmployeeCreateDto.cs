using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudAppliction.Models.Dtos
{
    public class EmployeeCreateDto
    {
        [Required(ErrorMessage = "First name is mandatory")]
        [StringLength(100, MinimumLength = 2)]
        public string EmpFirstname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is mandatory")]
        [StringLength(100, MinimumLength = 2)]
        public string EmpLastname { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string EmpEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is mandatory")]
        [StringLength(50, MinimumLength = 2)]
        public string EmpLocation { get; set; } = string.Empty;


        [Range(1000, 500000, ErrorMessage = "Salary must be between 1000 and 500000")]
        public decimal EmpSalary { get; set; }
    }
}
