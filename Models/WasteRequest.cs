using System;
using System.ComponentModel.DataAnnotations;

namespace WasteCollectionSystem.Models
{
    public class WasteRequest
    {
        [Key]
        public int RequestID { get; set; }

        public int UserID { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }

        [Required, StringLength(100)]
        public string WasteType { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";

        // Navigation
        public User User { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}

