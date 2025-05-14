using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CyberMLServiceSite.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="username is Required")]
        public string username { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string? RoleName  { get; set; }
    }
}
