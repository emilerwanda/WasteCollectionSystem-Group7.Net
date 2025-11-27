using System.ComponentModel.DataAnnotations;

namespace WasteCollectionSystem.Models
{
    public class Truck
    {
        [Key]
        public int TruckID { get; set; }

        [Required, StringLength(20)]
        public string PlateNumber { get; set; } = null!;

        [Required, StringLength(150)]
        public string DriverName { get; set; } = null!;

        public string Status { get; } = "Available"; // Available, Busy, Maintenance

        public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}