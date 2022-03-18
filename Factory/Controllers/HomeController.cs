using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.PageTitle = "Welcome to the To Do List!";
      return View();
    }
  }
}