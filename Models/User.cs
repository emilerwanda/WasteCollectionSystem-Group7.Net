using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WasteCollectionSystem.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required, StringLength(150)]
        public string FullName { get; set; }

        [Required, StringLength(20)]
        public string Phone { get; set; }

        [Required, StringLength(150)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } = "User";  // User or Admin

        public string Status { get; set; } = "Active";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<WasteRequest> WasteRequests { get; set; }
    }
}

