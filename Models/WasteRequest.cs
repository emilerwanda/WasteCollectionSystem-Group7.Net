using System;
using System.ComponentModel.DataAnnotations;

namespace WasteCollectionSystem.Models
{
    public class WasteRequest
    {
        [Key]
        public int RequestID { get; set; }

        // Changed from int UserID → string UserId (Identity uses string)
        public string UserId { get; set; } = null!;

        [Required, StringLength(255)]
        public string Location { get; set; } = null!;

        [Required, StringLength(100)]
        public string WasteType { get; set; } = null!;

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";

        // Navigation — now points to ApplicationUser
        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}