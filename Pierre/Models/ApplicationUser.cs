using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pierre.Models;

public class ApplicationUser: IdentityUser
{
  [Required(ErrorMessage = "You must enter a user name")]
  public string NickName { get; set; }
  [Display(Name = "Photo Url")]

  public string Image { get; set; }
  [DataType(DataType.Date)]
  public DateOnly Birthday { get; set; }
}