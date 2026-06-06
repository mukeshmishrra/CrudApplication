namespace CrudAppliction.Models.Dtos
{
    public class EmployeeResponseDto
    {
        public int EmpId { get; set; }
        public string EmpFirstname { get; set; } = string.Empty;
        public string EmpLastname { get; set; } = string.Empty;
        public string EmpEmail { get; set; } = string.Empty;
        public string EmpLocation { get; set; } = string.Empty;
        public decimal EmpSalary { get; set; }
    }
}
