using System.ComponentModel.DataAnnotations;

namespace GiBook.API.DTOs
{
  public class RegisterDto
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public string UserName { get; set; }
  }
}