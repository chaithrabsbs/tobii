using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tobii.Controllers
{
    public class HomeController : Controller
    {
        tobiiProductsEntities1 _context = new tobiiProductsEntities1();
        public ActionResult Index()
        {

            var listofProducts = _context.ProductLists.ToList();
            return View(listofProducts);

        }

        [HttpGet]
        public ActionResult Create()
        {
            //passing dropdown values to view
            var list1 = new List<string>() { "Peripheral", "Integrated" };
            ViewBag.list1 = list1;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductList list)
        {
            try
            {
                _context.ProductLists.Add(list);
                _context.SaveChanges();
                ViewBag.Message = "Product Added successfully";
                //passing dropdown values to view
                var list1 = new List<string>() { "Peripheral", "Integrated" };
                ViewBag.list1 = list1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.ProductLists.Where(x => x.Id == id).FirstOrDefault();
            
            //passing dropdown values to view
            var list1 = new List<string>() { "Peripheral", "Integrated" };
            ViewBag.list1 = list1;
            return View(data);

        }

        [HttpPost]
        public ActionResult Edit(ProductList list)
        {
            try
            {
                var data = _context.ProductLists.Where(x => x.Id == list.Id).FirstOrDefault();
                if (data != null)
                {
                    data.Name = list.Name;
                    data.Type = list.Type;
                    data.Price = list.Price;

                    _context.SaveChanges();
                    ViewBag.Message = "Product Updated Successfully";
                    //passing dropdown values to view
                    var list1 = new List<string>() { "Peripheral", "Integrated" };
                    ViewBag.list1 = list1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            return View();


            //return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = _context.ProductLists.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        
        public ActionResult Delete(ProductList product)
        {
            try
            {
                var data = _context.ProductLists.Where(x => x.Id == product.Id).FirstOrDefault();
                _context.ProductLists.Remove(data);
                _context.SaveChanges();
                ViewBag.Message = "Record Deleted Successfully";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}