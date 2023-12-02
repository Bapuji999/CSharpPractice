using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore3.Models
{
    class College
    {
        [Key]
        public int CollegeId { get; set; }
        public string CollegeName { get; set; }
        public string CollegeType { get; set; }
        public string CollegeAddress { get; set; }
        public int UniversityId { get; set; }
        [ForeignKey("UniversityId")]
        public University University { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
