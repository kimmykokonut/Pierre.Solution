using System.ComponentModel.DataAnnotations;
using System;

namespace Pierre.ViewModels;

public class RegisterViewModel
{
  [Required]
  [EmailAddress]
  [Display(Name = "Email Address")]
  public string Email { get; set; }

  [Required]
  [DataType(DataType.Password)]
  // [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{6,}$", ErrorMessage = "Your password must contain at least six characters, a capital letter, a lowercase letter, a number, and a special character.")]
  public string Password { get; set; }

  [Required]
  [DataType(DataType.Password)]
  [Display(Name = "Confirm password")]
  [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
  public string ConfirmPassword { get; set; }

  [Required]
  public string NickName { get; set; }
  [Display(Name = "Photo Url")]

  public string Image { get; set; }
  [DataType(DataType.Date)]

  public DateOnly Birthday { get; set; }
}