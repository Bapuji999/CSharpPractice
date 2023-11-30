using System.ComponentModel.DataAnnotations;

namespace EFCore1
{
    class fatherandson
    {
        [Key]
        public int Id { get; set; }
        public string PersonName { get; set; }
        public int FatherId { get; set; }
    }
}
