using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jooledotnet.DAL;
using jooledotnet.Models;

namespace jooledotnet.Controllers
{
    public class ProductsController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
       
        //public ActionResult Search(string term)
        //{

        //    using (var context = new ProductContext())
        //    {
        //        var results = context.Products
        //                    .Where(p => p.SubCategory.Contains(term))
        //                    .ToList();

        //        return View(results); // Returns the Search view with the results
        //    }
        //}
        public ActionResult Search(string searchQuery, decimal? minPrice, decimal? maxPrice)
        {
            using (var context = new ProductContext())
            {
                var results = context.Products
                             .Where(p => p.SubCategory.Contains(searchQuery))
                             .ToList();
                if (minPrice.HasValue)
                {
                    results = results.FindAll(p => p.Price >= minPrice.Value);
                }

                // Filter by maxPrice if it has a value
                if (maxPrice.HasValue)
                {
                    results = results.FindAll(p => p.Price <= maxPrice.Value);
                }
                ViewBag.searchQuery = searchQuery;
                return View(results); // Returns the Search view with the results
            }
        }

        public ActionResult AutoCompleteSearch(string term)
        {
            var results = db.Products
                .Where(d => d.SubCategory.StartsWith(term)).Select(d => new { label = d.Model }).ToList();
            return Json(results, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult Details(int id)
        //{
        //    using(var context = new ProductContext())
        //    {
        //        var product = context.Products.Where(p => p.ProductID == id);
        //        return View(product);

        //    }

        //}
        [HttpPost]
        public ActionResult Compare(int[] selectedProducts)
        {
            if (selectedProducts == null || selectedProducts.Length < 2 || selectedProducts.Length > 4)
            {
                // Handle error: You must select between 2 to 4 products to compare.
                 // Assuming "Index" is your search results page.
                 //alart 
            }

            var productsToCompare = db.Products.Where(p => selectedProducts.Contains(p.ProductID)).ToList();

            return View(productsToCompare);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
