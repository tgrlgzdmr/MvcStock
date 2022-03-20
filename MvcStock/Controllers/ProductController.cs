using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            var values = db.TblProducts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> values=(from i in db.TblCategories.ToList()
                                         select new SelectListItem
                                         {
                                             Text=i.CategoryName,
                                             Value=i.Categoryid.ToString(),
                                         }).ToList();
            ViewBag.vlu = values;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(TblProduct p3)
        {
            var ctg = db.TblCategories.Where(m => m.Categoryid == p3.TblCategory.Categoryid).FirstOrDefault();
            p3.TblCategory=ctg;
            db.TblProducts.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}