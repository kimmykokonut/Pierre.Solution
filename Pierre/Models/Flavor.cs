using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pierre.Models;

public class Flavor
{
  public int FlavorId { get; set; }
  [Required(ErrorMessage = "You must enter a type")]
  public string Type { get; set; }
  public List<FlavorTreat> FlavorTreats { get; }
}