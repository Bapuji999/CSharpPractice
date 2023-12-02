using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_4.Models
{
    class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string VehicleNo { get; set; }
        public string VehicleName { get; set; }
        public string Brand { get; set; }
        public int VehicleTypeId { get; set; }
        public bool isAvailable { get; set; } = true;
        public double PerDayPrice { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<VehicleIssue> VehicleIssue { get; set; }
    }
}
