using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore3.Models
{
    class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set;}
        public string StudentAddress { get; set; }
        public int Age { get; set; }
        public double StudentPercentage { get; set; } = 0;
        public double StudentMarks { get; set; }
        public string StudentResult { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
