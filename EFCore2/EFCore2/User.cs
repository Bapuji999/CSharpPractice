using System.ComponentModel.DataAnnotations;

namespace EFCore2
{
    class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
