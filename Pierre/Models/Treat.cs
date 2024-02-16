using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pierre.Models; 

public class Treat 
{
  public int TreatId { get; set; }
  [Required(ErrorMessage = "You must enter a name")]
  public string Name { get; set; }
  [Required(ErrorMessage = "You must enter a description")]

  public string Description { get; set; }
  [Required(ErrorMessage = "You must enter a price")]

  public int Price { get; set; }
  public DateOnly AddDate { get; set; } = DateOnly.DateTime.Now;
  public List<FlavorTreat> FlavorTreats { get; }
}
