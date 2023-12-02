using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_4.Models
{
    class PaymentDetails
    {
        [Key]
        public int PaymentId { get; set; }
        public virtual VehicleIssue VehicleIssue { get; set; }
        [ForeignKey("VehicleIssueId")]
        public int VehicleIssueId { get; set; }
        public double TotalRent { get; set; }
        public bool IsFullPaymentDone { get; set; } = false;
        public bool IsAdvancePaymentDone { get; set; } = false;
        public double TotalPayment { get; set; }
    }
}
