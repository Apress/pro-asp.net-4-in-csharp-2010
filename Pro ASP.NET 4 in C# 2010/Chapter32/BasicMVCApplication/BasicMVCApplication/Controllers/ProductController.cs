using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicMVCApplication.Models;

namespace BasicMVCApplication.Controllers {
    [HandleError(Order = 2)]
    public class ProductController : Controller {
        private NorthwindAccessConsolidator nwa
            = new NorthwindAccessConsolidator();

        //
        // GET: /Product/

        public ActionResult Index() {
            return View(nwa.ListProducts());
        }

        //
        // GET: /Product/Details/5

        [HandleError(View = "NoSuchRecordError", ExceptionType = typeof(NoSuchRecordException))]
        public ActionResult Details(int id) {
            Product prod = nwa.GetProduct(id);
            if (prod == null) {
                throw new NoSuchRecordException();
            } else {
                ViewData["CatName"] = nwa.GetCategoryName(prod);
                ViewData["SupName"] = nwa.GetSupplierName(prod);
                return View(prod);
            }
        }

        //
        // GET: /Product/Create

        public ActionResult Create() {
            return View(new Product());
        }

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product prod) {
            try {
                nwa.StoreNewProduct(prod);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id) {
            return View(nwa.GetProduct(id));
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                Product prod = nwa.GetProduct(id);
                if (prod != null) {
                    UpdateModel(prod);
                    nwa.SaveChanges();
                    return RedirectToAction("Index");
                } else {
                    throw new NoSuchRecordException();
                }
            } catch {
                return View();
            }
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id) {
            return View(nwa.GetProduct(id));
        }

        //
        // POST: /Product/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                nwa.DeleteProduct(id);
                return RedirectToAction("Index");
            } catch (Exception ex) {
                Console.WriteLine(ex);
                return View();
            }
        }
    }

    class NorthwindAccessConsolidator {
        private NorthwindEntities db = new NorthwindEntities();

        public IEnumerable<Product> ListProducts() {
            return db.Products;
        }

        public Product GetProduct(int id) {
            IEnumerable<Product> data = db.Products
                .Where(e => e.ProductID == id)
                .Select(e => e);
            return data.Count() > 0 ? data.Single() : null;
        }

        public void DeleteProduct(int id) {
            Product prod = GetProduct(id);
            if (prod != null) {
                IEnumerable<Order_Detail> ods = 
                    db.Order_Details
                    .Where(e => e.ProductID == id)
                    .Select(e => e);
                foreach (Order_Detail od in ods) {
                    db.Order_Details.DeleteObject(od);
                }
                
                db.Products.DeleteObject(prod);
                SaveChanges();
            }
        }

        public string GetSupplierName(Product prod) {
            return db.Suppliers
                .Where(e => e.SupplierID == prod.SupplierID)
                .Select(e => e.CompanyName)
                .Single();
        }

        public string GetCategoryName(Product prod) {
            return db.Categories
                .Where(e => e.CategoryID == prod.CategoryID)
                .Select(e => e.CategoryName)
                .Single();
        }

        public void StoreNewProduct(Product prod) {
            db.Products.AddObject(prod);
            SaveChanges();
        }

        public void SaveChanges() {
            db.SaveChanges();
        }
    }

    class NoSuchRecordException : Exception {
    }
}
