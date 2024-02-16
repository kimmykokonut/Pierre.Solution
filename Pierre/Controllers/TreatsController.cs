using Microsoft.AspNetCore.Mvc;
using Pierre.Models; 
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Pierre.Controllers;

public class TreatsController : Controller
{
  private readonly PierreContext _db;
  public ClassNameSController(PierreContext db)
  {
    _db = db;
  }
  public ActionResult Index()
  {
    return View();
    // List<ClassName> model = _db.Stylists.ToList();
    // return View(model);
  }
}
