using System.ComponentModel.DataAnnotations;

namespace WasteCollectionSystem.Models
{
    public class Truck
    {
        [Key]
        public int TruckID { get; set; }

        [Required, StringLength(20)]
        public string PlateNumber { get; set; }

        [Required, StringLength(150)]
        public string DriverName { get; set; }

        public string Status { get; set; } = "Available"; // Available, Busy, Maintenance

        // Navigation
        public ICollection<Assignment> Assignments { get; set; }
    }
}

