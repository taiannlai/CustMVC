using CustomerMVC.Models;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerMVC.Controllers
{
    public class CustomerDataController : Controller
    {
        CustomerDataEntities db = new CustomerDataEntities();
        // GET: CustomerData
        public ActionResult Index()
        {
            return View(db.客戶資料.ToList().Where(p => p.IsDelete == false));
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(客戶資料 customerdata)
        {
            if (ModelState.IsValid)
            {
                db.客戶資料.Add(customerdata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerdata);
        }
        public ActionResult Edit(int? id)
        {
            var cut = db.客戶資料.Find(id);
            return View(cut);
        }
        [HttpPost]
        public ActionResult Edit(int id,CustomerEdit customerdata)
        {
            if (ModelState.IsValid)
            {
                var cut = db.客戶資料.Find(id);
                cut.InjectFrom(customerdata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerdata);
        }
        public ActionResult Delete(int? id)
        {

            return View(db.客戶資料.Find(id.Value));
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var item = db.客戶資料.Find(id);
                item.IsDelete = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(db.客戶資料.Find(id));
        }
        public ActionResult Detials(int? id)
        {
            var cust = db.客戶資料.Find(id);
            return View(cust);
        }
        [HttpPost]
        public ActionResult Detials(int? id,客戶資料 customerdata)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }

            return View(customerdata);
        }
    }
}