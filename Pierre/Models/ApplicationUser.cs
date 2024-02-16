using Microsoft.AspNetCore.Identity;
using System;

namespace Pierre.Models;

public class ApplicationUser: IdentityUser
{
  public string NickName { get; set; }

  public string Image { get; set; }
  public DateOnly Bithday { get; set; }
}