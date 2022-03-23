using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class SalesController : Controller
    {
        MvcDbStockEntities db = new MvcDbStockEntities();
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult NewSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSales(TblSale p4)
        {
            db.TblSales.Add(p4);
            db.SaveChanges();
            return View("Index");
        }
    }
}