using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrnixMotors.Areas.Admin.ViewModels;
using OrnixMotors.Data;
using OrnixMotors.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrnixMotors.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AchievementsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AchievementsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Achievements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Achievements.ToListAsync());
        }

        // POST: Admin/Achievements/CreateOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(AchievementViewModel viewModel)
        {
            ModelState.Remove("ImageFile");
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0) 
                {
                    string uniqueFileName = await UploadImage(viewModel);
                    Achievement achievement = new Achievement
                    {
                        Description = viewModel.Description,
                        ImageUrl = uniqueFileName
                    };
                    _context.Add(achievement);
                    TempData["SuccessMessage"] = "تمت إضافة الإنجاز بنجاح!";
                }
                else 
                {
                    var achievementToUpdate = await _context.Achievements.FindAsync(viewModel.Id);
                    if (achievementToUpdate == null) return NotFound();

                    if (viewModel.ImageFile != null)
                    {
                        
                        if (!string.IsNullOrEmpty(achievementToUpdate.ImageUrl))
                        {
                            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/achievements", achievementToUpdate.ImageUrl);
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }
                        // Upload new image
                        achievementToUpdate.ImageUrl = await UploadImage(viewModel);
                    }
                    achievementToUpdate.Description = viewModel.Description;
                    _context.Update(achievementToUpdate);
                    TempData["SuccessMessage"] = "تم تعديل الإنجاز بنجاح!";
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // If model state is invalid, redirect back with an error message
            TempData["ErrorMessage"] = "حدث خطأ ما. يرجى مراجعة البيانات المدخلة.";
            return RedirectToAction(nameof(Index));
        }


        // GET: Admin/Achievements/GetAchievement/5
        [HttpGet]
        public async Task<JsonResult> GetAchievement(int id)
        {
            var achievement = await _context.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return Json(null);
            }
            return Json(new { id = achievement.Id, description = achievement.Description, imageUrl = achievement.ImageUrl });
        }


        // POST: Admin/Achievements/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var achievement = await _context.Achievements.FindAsync(id);
            if (achievement == null)
            {
                TempData["ErrorMessage"] = "الإنجاز غير موجود!";
                return RedirectToAction(nameof(Index));
            }

            // Delete the image file from wwwroot
            if (!string.IsNullOrEmpty(achievement.ImageUrl))
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/achievements", achievement.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _context.Achievements.Remove(achievement);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "تم حذف الإنجاز بنجاح!";
            return RedirectToAction(nameof(Index));
        }

        private async Task<string> UploadImage(AchievementViewModel viewModel)
        {
            string uniqueFileName = null;
            if (viewModel.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/achievements");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await viewModel.ImageFile.CopyToAsync(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}

