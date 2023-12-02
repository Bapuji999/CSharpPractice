using System.ComponentModel.DataAnnotations;

namespace Project_4.Models
{
    class VehicleType
    {
        [Key]
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
    }
}
