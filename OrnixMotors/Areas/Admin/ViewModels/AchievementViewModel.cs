using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OrnixMotors.Areas.Admin.ViewModels
{
    public class AchievementViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "حقل الوصف مطلوب.")]
        [Display(Name = "الوصف")]
        public string Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "الرجاء اختيار صورة.")]
        [Display(Name = "الصورة")]
        public IFormFile ImageFile { get; set; }
    }
}
