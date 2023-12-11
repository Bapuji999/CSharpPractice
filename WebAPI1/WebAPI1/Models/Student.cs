using System.ComponentModel.DataAnnotations;

namespace WebAPI1.Models
{
    public interface IStudents
    {
        public List<Student> students { get; set; }
    }
    public class Students : IStudents
    {
        public List<Student> students { get; set; } = new List<Student>();
    }
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        public int Class { get; set; }
    }
}
