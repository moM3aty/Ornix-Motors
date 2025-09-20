using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrnixMotors.Data;
using OrnixMotors.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OrnixMotors.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                SiteSettings = await _context.SiteSettings.FirstOrDefaultAsync(),
                Achievements = await _context.Achievements.ToListAsync()
            };
            return View(viewModel);
        }
    }
}
