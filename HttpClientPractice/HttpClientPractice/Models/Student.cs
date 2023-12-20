using System.ComponentModel.DataAnnotations;

namespace WebAPI1.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Class { get; set; }
    }
}
