using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pierre.Controllers;

public class HomeController : Controller
{
  private readonly PierreContext _db;
  public HomeController(PierreContext db)
  {
    _db = db;
  }

  [HttpGet("/")]
  public ActionResult Index()
  {
    Treat[] treats = _db.Treats.ToArray();
    Flavor[] flavors = _db.Flavors.ToArray();
    Dictionary<string, object[]> model = new Dictionary<string, object[]>();
    model.Add("treats", treats);
    model.Add("flavors", flavors);
    return View(model);
  }
}
