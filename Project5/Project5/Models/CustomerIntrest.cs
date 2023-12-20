using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project5.Models
{
    public class CustomerIntrest
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public User Customer { get; set; }
        public Product Product { get; set; }
    }
}
