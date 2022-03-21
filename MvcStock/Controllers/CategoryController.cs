using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;


namespace MvcStock.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            var values = db.TblCategories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategory p1)
        {
            if(!ModelState.IsValid)
            {
                return View("AddCategory");
            }

            db.TblCategories.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var category = db.TblCategories.Find(id);
            db.TblCategories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PullCategory(int id)
        {
            var ctgr = db.TblCategories.Find(id);
            return View("PullCategory",ctgr);
        }

        public ActionResult Update(TblCategory p1)
        {
            var ctg=db.TblCategories.Find(p1.Categoryid);
            ctg.CategoryName=p1.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}