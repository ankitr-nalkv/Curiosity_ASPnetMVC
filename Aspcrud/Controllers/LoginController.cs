using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspcrud.Models;

namespace Aspcrud.Controllers
{
  //[SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]
  public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(member memberModel)
        {
          using(DBModel dbModel = new DBModel())
          {
            var userDetail = dbModel.members.Where(x => x.uname == memberModel.uname && x.pass == memberModel.pass).FirstOrDefault();
        if (userDetail == null)
        {
          memberModel.LoginErrorMessage = "Wrong Username or Password";
          return View("Index", memberModel);
        }
        else
        {
          TempData["id"] = userDetail.uname;
          return RedirectToAction("Index", "Home");
        }
          }
          //return View();
        }
    public ActionResult Logout()
    {
      TempData.Clear();
      return RedirectToAction("Index", "Article");
    }
    public ActionResult Register()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Register(member memberModel)
    {
      using (DBModel dbModel = new DBModel())
      {

        dbModel.members.Add(memberModel);
        dbModel.SaveChanges();
      }
      return RedirectToAction("Index","Home");
    }
  }
}
