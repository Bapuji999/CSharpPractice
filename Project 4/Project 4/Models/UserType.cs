using System.ComponentModel.DataAnnotations;

namespace Project_4.Models
{
    class UserType
    {
        [Key] 
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
    }
}
