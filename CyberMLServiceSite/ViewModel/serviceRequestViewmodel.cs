using System.ComponentModel.DataAnnotations;

namespace CyberMLServiceSite.ViewModel
{
    public class ServiceRequestViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; } = string.Empty;

        [Required(ErrorMessage = "At least one service must be selected")]
        public string ServicesRequested { get; set; } = string.Empty;

        public string AdditionalNotes { get; set; } = string.Empty;
    }
}