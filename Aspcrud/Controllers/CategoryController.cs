using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspcrud.Models;

namespace Aspcrud.Controllers
{
  public class CategoryController : Controller
  {
    // GET: Category
    //public ActionResult Index()
    //{
    //    return View();
    //}

    // GET: Category/Details/Space
    public ActionResult Details(String id)
    {
      TempData.Keep("id");
      List<article> articleModel = new List<article>();
      using (DBModel dbModel = new DBModel())
      {
        articleModel = dbModel.articles.Where(x => x.category == id).ToList<article>();
      }

      return View(articleModel);
    }

    //// GET: Category/Create
    //public ActionResult Create()
    //{
    //    return View();
    //}

    //// POST: Category/Create
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

    //// GET: Category/Edit/5
    //public ActionResult Edit(int id)
    //{
    //    return View();
    //}

    //// POST: Category/Edit/5
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

    //// GET: Category/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: Category/Delete/5
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
