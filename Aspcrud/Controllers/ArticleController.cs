using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspcrud.Models;

namespace Aspcrud.Controllers
{
  public class ArticleController : Controller
  {
    // GET: Article
    public ActionResult Index()
    {
      List<article> articleList = new List<article>();
      using (DBModel dbModel = new DBModel())
      {
        articleList = dbModel.articles.ToList<article>();
      }
      return View(articleList);
    }

    // GET: Article/Details/5
    public ActionResult Details(int id)
    {
      TempData.Keep("id");
      article articleModel = new article();
      using (DBModel dbModel = new DBModel())
      {
        articleModel = dbModel.articles.Where(x => x.id == id).FirstOrDefault();
      }

      return View(articleModel);
    }

    // GET: Article/Create
    public ActionResult Create()
    {
      TempData.Keep("id");
      return View(new article());
    }

    // POST: Article/Create
    [HttpPost]
    public ActionResult Create(String Title, String category, String description, String imageurl)
    {
      TempData.Keep("id");
      if(TempData["id"] == null)
      {
        return RedirectToAction("Index", "Login");
      }
      String uname = TempData["id"].ToString();
      article articleModel = new article();
      member memberModel = new member();
      articleModel.Title = Title;
      articleModel.category = category;
      articleModel.description = description;
      articleModel.imageurl = imageurl;
      articleModel.source = uname;
      articleModel.vote = 0;
      
      using (DBModel dbModel = new DBModel())
      {
        memberModel = dbModel.members.Where(x => x.uname == uname).FirstOrDefault();
        articleModel.userid = memberModel.id;
        dbModel.articles.Add(articleModel);
        dbModel.SaveChanges();
      }
      return RedirectToAction("Index", "Home");
    }

    // GET: Article/Edit/5
    public ActionResult Edit(int id)
    {
      TempData.Keep("id");
      article articleModel = new article();
      using (DBModel dbModel = new DBModel())
      {
        articleModel = dbModel.articles.Where(x => x.id == id).FirstOrDefault();
      }

      return View(articleModel);
    }

    // POST: Article/Edit/5
    [HttpPost]
    public ActionResult Edit(article articleModel)
    {
      TempData.Keep("id");
      using (DBModel dbModel = new DBModel())
      {
        dbModel.Entry(articleModel).State = System.Data.Entity.EntityState.Modified;
        dbModel.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    // GET: Article/Delete/5
    public ActionResult Delete(int id)
    {
      TempData.Keep("id");
      article articleModel = new article();
      using (DBModel dbModel = new DBModel())
      {
        articleModel = dbModel.articles.Where(x => x.id == id).FirstOrDefault();
      }

      return View(articleModel);
    }

    // POST: Article/Delete/5
    [HttpPost]
    public ActionResult Delete(article articleModel)
    {
      TempData.Keep("id");
      using (DBModel dbModel = new DBModel())
      {
        dbModel.Entry(articleModel).State = System.Data.Entity.EntityState.Modified;
        dbModel.articles.Remove(articleModel);
        dbModel.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult UpdateVote(String vote, String id, String user)
    {
      TempData.Keep("id");
      int updateVote = int.Parse(vote);
      updateVote = updateVote + 1;
      short articleId = short.Parse(id);
      votetable newVote = new votetable();
      article articleModel = new article();
      member memberModel = new member();
      using(DBModel dbModel = new DBModel())
      {
        memberModel = dbModel.members.Where(x => x.uname == user).FirstOrDefault();
        newVote.userId = memberModel.id;
        newVote.articleId = articleId;
        
        articleModel = dbModel.articles.Where(x => x.id == articleId).FirstOrDefault();
        articleModel.vote = updateVote;
        try
        {
          dbModel.votetables.Add(newVote);
          dbModel.SaveChanges();
        }
        catch
        {
          String errorInfo = "already";
          return Json(errorInfo);
        }
        if(updateVote == 150)
        {
          dbModel.Entry(articleModel).State = System.Data.Entity.EntityState.Modified;
          dbModel.articles.Remove(articleModel);
          dbModel.SaveChanges();
          String deleteArticle = "deleted";
          return Json(deleteArticle);
        }
        dbModel.Entry(articleModel).State = System.Data.Entity.EntityState.Modified;
        dbModel.SaveChanges();
      }
      
      return Json(updateVote);
    }
  }
}
