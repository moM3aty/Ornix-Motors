using System.ComponentModel.DataAnnotations;

namespace OrnixMotors.Models
{
    public class SiteSettings
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "حقل رقم الهاتف الأول مطلوب.")]
        [Display(Name = "رقم الهاتف الأساسي")]
        [Phone(ErrorMessage = "الرجاء إدخال رقم هاتف صحيح.")]
        public string PhoneNumber1 { get; set; }

        [Required(ErrorMessage = "حقل رقم الهاتف الثاني مطلوب.")]
        [Display(Name = "رقم الواتساب (والهاتف الثاني)")]
        [Phone(ErrorMessage = "الرجاء إدخال رقم هاتف صحيح.")]
        public string PhoneNumber2 { get; set; }

        [Required(ErrorMessage = "حقل رقم الواتساب مطلوب.")]
        [Display(Name = "رقم الواتساب (للربط المباشر)")]
        public string WhatsAppNumber { get; set; }

        [Required(ErrorMessage = "حقل البريد الإلكتروني مطلوب.")]
        [Display(Name = "البريد الإلكتروني")]
        [EmailAddress(ErrorMessage = "الرجاء إدخال بريد إلكتروني صحيح.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "حقل رابط فيسبوك مطلوب.")]
        [Display(Name = "رابط صفحة فيسبوك")]
        [Url(ErrorMessage = "الرجاء إدخال رابط صحيح.")]
        public string FacebookLink { get; set; }

        [Required(ErrorMessage = "حقل رابط انستغرام مطلوب.")]
        [Display(Name = "رابط صفحة انستغرام")]
        [Url(ErrorMessage = "الرجاء إدخال رابط صحيح.")]
        public string InstagramLink { get; set; }

        [Required(ErrorMessage = "حقل عنوان الإسكندرية مطلوب.")]
        [Display(Name = "عنوان فرع الإسكندرية")]
        public string AlexAddress { get; set; }

        [Required(ErrorMessage = "حقل رابط خريطة الإسكندرية مطلوب.")]
        [Display(Name = "كود تضمين خريطة الإسكندرية (iframe)")]
        public string AlexLocationUrl { get; set; }

        [Required(ErrorMessage = "حقل عنوان القاهرة مطلوب.")]
        [Display(Name = "عنوان فرع القاهرة")]
        public string CairoAddress { get; set; }

        [Required(ErrorMessage = "حقل رابط خريطة القاهرة مطلوب.")]
        [Display(Name = "كود تضمين خريطة القاهرة (iframe)")]
        public string CairoLocationUrl { get; set; }
    }
}

