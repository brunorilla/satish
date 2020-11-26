using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satish.Controllers
{
    public class CheckoutStep2Controller : Controller
    {
        // GET: CheckoutStep2Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: CheckoutStep2Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CheckoutStep2Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckoutStep2Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {   
                Console.WriteLine(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckoutStep2Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckoutStep2Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckoutStep2Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckoutStep2Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
