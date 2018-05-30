using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspcrud.Models;

namespace Aspcrud.Controllers
{
  public class MembersController : Controller
  {
    // GET: Members
    //public ActionResult Index()
    //{
    //    return View();
    //}

    // GET: Members/Details/5
    public ActionResult Details(String id)
    { 
      member memberModel = new member();
      List<article> articleModel = new List<article>();
      TempData.Keep("id");
      using (DBModel dbModel = new DBModel())
      {
        memberModel = dbModel.members.Where(x => x.uname == id).FirstOrDefault();
      }
      using (DBModel dbModel = new DBModel())
      {
        articleModel = dbModel.articles.Where(x => x.userid == memberModel.id).ToList<article>();
      }
      ViewData["Member"] = memberModel;
      ViewData["Articles"] = articleModel;
      return View();
    }

    // GET: Members/Create
    //public ActionResult Create()
    //{
    //    return View();
    //}

    //// POST: Members/Create
    //[HttpPost]
    //public ActionResult Create(FormCollection collection)
    //{
    //    try
    //    {
    //        // TODO: Add insert logic here

    //        return RedirectToAction("Index");
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: Members/Edit/5
    //public ActionResult Edit(int id)
    //{
    //    return View();
    //}

    //// POST: Members/Edit/5
    //[HttpPost]
    //public ActionResult Edit(int id, FormCollection collection)
    //{
    //    try
    //    {
    //        // TODO: Add update logic here

    //        return RedirectToAction("Index");
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: Members/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: Members/Delete/5
    //[HttpPost]
    //public ActionResult Delete(int id, FormCollection collection)
    //{
    //    try
    //    {
    //        // TODO: Add delete logic here

    //        return RedirectToAction("Index");
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}
  }
}
