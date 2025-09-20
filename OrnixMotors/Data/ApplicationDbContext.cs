using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrnixMotors.Models;

namespace OrnixMotors.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SiteSettings> SiteSettings { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SiteSettings>().HasData(
                new SiteSettings
                {
                    Id = 1,
                    PhoneNumber1 = "01012377308",
                    PhoneNumber2 = "01284828841",
                    WhatsAppNumber = "201284828841",
                    Email = "ornixmotorslimousinservies@gmail.com",
                    FacebookLink = "https://www.facebook.com/share/161FhEvXhR/",
                    InstagramLink = "https://www.instagram.com/",
                    AlexAddress = "السيوف، بجوار كارفور سيتي لايت",
                    AlexLocationUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3412.590130831649!2d29.97017867560045!3d31.204369974359416!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14f5c531d23315a1%3A0x256e2938812c22c1!2sCarrefour%20City%20Light!5e0!3m2!1sen!2seg!4v1694977893706!5m2!1sen!2seg\" width=\"100%\" height=\"350\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>",
                    CairoAddress = "مساكن شيراتون المطار",
                    CairoLocationUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d13809.529897148818!2d31.362142168537553!3d30.083236302568656!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x1458165d21e84eab%3A0xe522384a51939105!2sSheraton%20Al%20Matar%2C%20El%20Nozha%2C%20Cairo%20Governorate!5e0!3m2!1sen!2seg!4v1694977953258!5m2!1sen!2seg\" width=\"100%\" height=\"350\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>"
                }
            );
        }
    }
}

