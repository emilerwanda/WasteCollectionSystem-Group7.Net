using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WasteCollectionSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(150)]
        public string FullName { get; set; } = null!;

        // Using the inherited PhoneNumber from IdentityUser, but also keeping Phone for compatibility
        [StringLength(20)]
        public string? Phone { get; set; }

        [Required]
        public string Role { get; set; } = "User"; // User, Admin, Driver, Manager, Supervisor

        public string Status { get; set; } = "Active";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public virtual ICollection<WasteRequest> WasteRequests { get; set; } =
            new List<WasteRequest>();
        
        // Helper to get display name with fallback
        public string DisplayName => !string.IsNullOrEmpty(FullName) ? FullName : Email ?? UserName ?? "User";
    }
}
