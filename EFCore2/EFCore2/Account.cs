using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore2
{
    class Account
    {
        [Key]
        public int AccountId { get; set; }
        public int Balance {  get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
