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
  public ActionResult Details(int id)
  {
    Treat thisTreat = _db.Treats
    .Include(treat => treat.FlavorTreats)
    .ThenInclude(join => join.Flavor)
    .FirstOrDefault(treat => treat.TreatId == id);
    return View(thisTreat);
  }
  public ActionResult Edit(int id)
  {
    Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
    return View(thisTreat);
  }
  [HttpPost]
  public ActionResult Edit(Treat treat)
  {
    _db.Treats.Update(treat);
    _db.SaveChanges();
    return RedirectToAction("Details", new { id = treat.TreatId });
  }
  public ActionResult Delete(int id)
  {
    Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
    return View(thisTreat);
  }
  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
    _db.Treats.Remove(thisTreat);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
  public ActionResult AddFlavor(int id)
  {
    Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
    ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Type");
    return View(thisTreat);
  }
  [HttpPost]
  public ActionResult AddFlavor(Treat treat, int flavorId)
  {
        #nullable enable
        FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(join => (join.FlavorId == flavorId && join.TreatId == treat.TreatId));
        #nullable disable
        if (joinEntity == null && flavorId != 0)
        {
          _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = flavorId, TreatId = treat.TreatId });
          _db.SaveChanges();
        }
    return RedirectToAction("Details", new { id = treat.TreatId });
  }

}
