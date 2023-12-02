using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore3.Models
{
    class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public int NuumberOfClass { get; set; }
        public string DepartmentHead { get; set; }
        public int CollegeId { get; set; }
        [ForeignKey("CollegeId")]
        public College College { get; set; }
        public ICollection<Professor> Professors { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
