using System.ComponentModel.DataAnnotations;

namespace OrnixMotors.Models
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "حقل الوصف مطلوب.")]
        [Display(Name = "الوصف")]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
