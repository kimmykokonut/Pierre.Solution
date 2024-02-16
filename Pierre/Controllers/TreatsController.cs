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
  public TreatsController(PierreContext db)
  {
    _db = db;
  }
  public ActionResult Index()
  {
    List<Treat> model = _db.Treats.ToList();
    return View(model);
  }
  public ActionResult Create()
  {
    return View();
  }
  [HttpPost]
  public ActionResult Create(Treat treat)
  {
    if (!ModelState.IsValid)
    {
      return View(treat);
    }
    else
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
