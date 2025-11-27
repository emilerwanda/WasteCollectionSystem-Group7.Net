using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WasteCollectionSystem.Data;
using WasteCollectionSystem.Models;

namespace WasteCollectionSystem.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public int TotalUsers { get; set; }
        public int TotalDrivers { get; set; }
        public int TotalRequests { get; set; }
        public int TotalTrucks { get; set; }
        public List<ApplicationUser> RecentUsers { get; set; } = new();
        public List<WasteRequest> RecentRequests { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            // Get statistics
            TotalUsers = await _userManager.Users.CountAsync();
            TotalDrivers = await _userManager.Users.CountAsync(u => u.Role == "Driver");
            TotalRequests = await _context.WasteRequests.CountAsync();
            TotalTrucks = await _context.Trucks.CountAsync();

            // Get recent users (last 5)
            RecentUsers = await _userManager.Users
                .OrderByDescending(u => u.CreatedAt)
                .Take(5)
                .ToListAsync();

            // Get recent requests (last 5)
            RecentRequests = await _context.WasteRequests
                .Include(r => r.User)
                .OrderByDescending(r => r.RequestDate)
                .Take(5)
                .ToListAsync();

            return Page();
        }
    }
}

