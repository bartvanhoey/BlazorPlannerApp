using System.ComponentModel.DataAnnotations;

namespace PlannerApp.Shared.Models
{
  public class LoginRequest
  {
    [Required]
    [StringLength(50)]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Password { get; set; }
  }
}