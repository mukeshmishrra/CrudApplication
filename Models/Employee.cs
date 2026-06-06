using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudAppliction.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmpFirstname { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string EmpLastname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string EmpEmail { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string EmpLocation { get; set; } = string.Empty;


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal EmpSalary { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
