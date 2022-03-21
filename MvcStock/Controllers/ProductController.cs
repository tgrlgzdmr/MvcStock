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

        public ActionResult Delete(int id)
        {
            var product = db.TblProducts.Find(id);
            db.TblProducts.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PullProduct(int id)
        {
            var prd = db.TblProducts.Find(id);

            List<SelectListItem> values = (from i in db.TblCategories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.Categoryid.ToString(),
                                           }).ToList();
            ViewBag.vlu = values;

            return View("PullProduct",prd);
        }

        public ActionResult Update(TblProduct p3)
        {
            var ctg =db.TblCategories.Where(m => m.Categoryid == p3.TblCategory.Categoryid).FirstOrDefault();
            var prd =db.TblProducts.Find(p3.Productid);
            p3.TblCategory= ctg;
            prd.ProductName = p3.ProductName;
            prd.ProductBrand = p3.ProductBrand;
            prd.ProductCategory = ctg.Categoryid;
            prd.ProductPrice = p3.ProductPrice;
            prd.ProductStock= p3.ProductStock;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}