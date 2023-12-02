using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_4.Models
{
    class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string LicenceNo { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        public int UserTypeId { get; set; } = 3;
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<VehicleIssue> VehicleIssue { get; set; }
    }
}
