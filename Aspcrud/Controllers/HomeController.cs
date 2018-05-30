using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspcrud.Models;
using System.Web.SessionState;

namespace Aspcrud.Controllers
{
  [SessionState(SessionStateBehavior.Default)]
  public class HomeController : Controller
  {
    
    public ActionResult Index()
    {
      TempData.Keep("id");
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}
