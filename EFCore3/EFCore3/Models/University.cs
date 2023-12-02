using System.ComponentModel.DataAnnotations;

namespace EFCore3.Models
{
    class University
    {
        [Key]
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
        public string UnversityType { get; set; }
        public string UnvesrsityGrade { get; set; }
        public string UnversityAddress { get; set; }
        public ICollection<College> Colleges { get; set; }
    }
}
