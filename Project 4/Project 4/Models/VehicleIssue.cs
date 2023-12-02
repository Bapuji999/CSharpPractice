using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_4.Models
{
    class VehicleIssue
    {
        [Key]
        public int VehicleIssueId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual Vehicle vehicle { get; set; }
        [ForeignKey("VehicleId")]
        public int VehicleId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; } = null;
        public virtual PaymentDetails PaymentDetails { get; set; }
    }
}
