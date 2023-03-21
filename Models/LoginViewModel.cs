using System.ComponentModel.DataAnnotations;

namespace CmsCommerce.Models;

public class LoginViewModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
