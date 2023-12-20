using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project5.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RollId { get; set; }
        [Required]
        public bool IsActive { get; set; } = true; 
        public ICollection<Product> Products { get; set; }
        public ICollection<CustomerIntrest> CustomerIntrests { get; set; }
    }
}
