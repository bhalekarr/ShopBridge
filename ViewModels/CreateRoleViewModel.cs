using System.ComponentModel.DataAnnotations;

namespace ShopBridge.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
