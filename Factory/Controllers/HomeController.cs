using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    private readonly FactoryContext _db;

    public HomeController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      ViewBag.Engineers = _db.Engineers.ToList();
      ViewBag.Machines = _db.Machines.ToList();
      ViewBag.PageTitle = "Welcome to the Factory Manager!";
      return View();
    }
  }
}