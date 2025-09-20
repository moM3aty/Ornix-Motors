using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrnixMotors.Data;
using OrnixMotors.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OrnixMotors.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var settings = await _context.SiteSettings.FirstOrDefaultAsync();
            if (settings == null)
            {
                // Create a default settings object if none exists
                settings = new SiteSettings();
                _context.SiteSettings.Add(settings);
                await _context.SaveChangesAsync();
            }
            return View(settings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id, [Bind("Id,PhoneNumber1,PhoneNumber2,WhatsAppNumber,Email,FacebookLink,InstagramLink,AlexAddress,AlexLocationUrl,CairoAddress,CairoLocationUrl")] SiteSettings siteSettings)
        {
            if (id != siteSettings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siteSettings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.SiteSettings.Any(e => e.Id == siteSettings.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["SuccessMessage"] = "تم حفظ التغييرات بنجاح!";
                return RedirectToAction(nameof(Index));
            }
            return View(siteSettings);
        }
    }
}

