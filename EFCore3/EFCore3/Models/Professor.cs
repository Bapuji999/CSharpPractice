using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore3.Models
{
    class Professor
    {
        [Key]
        public int ProfessorId { get; set; }
        [Required]
        public string ProfessorName { get; set; }
        public string ProfessorAddress { get; set; }
        public int ProfessorAge { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
