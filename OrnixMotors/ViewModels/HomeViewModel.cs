using OrnixMotors.Models;
using System.Collections.Generic;

namespace OrnixMotors.ViewModels
{
    public class HomeViewModel
    {
        public SiteSettings SiteSettings { get; set; }
        public List<Achievement> Achievements { get; set; }
    }
}
