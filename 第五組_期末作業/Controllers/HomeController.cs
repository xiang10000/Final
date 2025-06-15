using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第五組_期末作業.Models;

namespace 第五組_期末作業.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        AdventureWorksLT2022Entities1 db = new AdventureWorksLT2022Entities1();
        public ActionResult Index()
        {
            var porduct = db.Product.OrderByDescending(x => x.ProductID).ToList();
            return View(porduct);
        }
        public ActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
        string Name,
        string ProductNumber,
        string Color,
        decimal StandardCost,
        decimal ListPrice,
        string Size,
        decimal Weight,
        int ProductModelID,
        DateTime SellStartDate,
        DateTime SellEndDate)
        {
            var product = new Product
            {
                Name = Name,
                ProductNumber = ProductNumber,
                Color = Color,
                StandardCost = StandardCost,
                ListPrice = ListPrice,
                Size = Size,
                Weight = Weight,                
                ProductModelID = ProductModelID,
                SellStartDate = SellStartDate,
                SellEndDate = SellEndDate,
                rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };            
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
        }
        public ActionResult Delete(int ProductID)
        {
            var porduct = db.Product.Where(m=>m.ProductID == ProductID).FirstOrDefault();
            db.Product.Remove(porduct);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
 
