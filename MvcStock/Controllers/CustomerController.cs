using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            var values=db.TblCustomers.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(TblCustomer p2)
        {
            if(!ModelState.IsValid)
            {
                return View("AddCustomer");
            }
            db.TblCustomers.Add(p2);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var customer = db.TblCustomers.Find(id);
            db.TblCustomers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PullCustomer(int id)
        {
            var cus = db.TblCustomers.Find(id);
            return View("PullCustomer",cus);
        }

        public ActionResult Update(TblCustomer p2)
        {
            var cus =db.TblCustomers.Find(p2.Customerid);
            cus.CustomerName=p2.CustomerName;
            cus.CustomerSurname=p2.CustomerSurname;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
            
    }
}