using System.ComponentModel.DataAnnotations;

namespace ShopBridge.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
