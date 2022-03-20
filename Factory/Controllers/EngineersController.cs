using Factory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "Engineers";
      return View(_db.Engineers.ToList());
    }
    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add Engineer";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Engineer engineer = _db.Engineers
        .Include(engineer => engineer.JoinEntities)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.PageTitle = "Engineer Details";
      return View(engineer);
    }

    public ActionResult Edit(int id)
    {
      Engineer engineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.PageTitle = "Edit Engineer";
      return View(engineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineer.EngineerId });
    }

    public ActionResult AddMachine(int id)
    {
      Engineer engineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
      ViewBag.PageTitle = "Add Repair License";
      return View(engineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int machineId)
    {
      if (machineId != 0)
      {
        _db.RepairLicenses.Add(new RepairLicense() { MachineId = machineId, EngineerId = engineer.EngineerId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = engineer.EngineerId });
    }

    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
      RepairLicense joinEntry = _db.RepairLicenses.FirstOrDefault(entry => entry.RepairLicenseId == joinId);
      _db.RepairLicenses.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = joinEntry.EngineerId });
    }

    public ActionResult Delete(int id)
    {
      Engineer engineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.PageTitle = "Delete Engineer";
      return View(engineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Engineer engineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(engineer);
      foreach(RepairLicense join in engineer.JoinEntities)
      {
        _db.RepairLicenses.Remove(join);
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}