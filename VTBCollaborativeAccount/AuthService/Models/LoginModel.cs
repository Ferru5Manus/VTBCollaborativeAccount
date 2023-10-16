using System.ComponentModel.DataAnnotations;
using AuthService.Models.Attributes;

namespace AuthService.Models;

public class LoginModel
{
    [Required(ErrorMessage ="Device id missing!")]
    public string deviceId {  get; set; }
    
}