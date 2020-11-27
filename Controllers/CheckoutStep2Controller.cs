using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Satish.Models;
using Satish.Data;


namespace Satish.Controllers
{
    public class CheckoutStep2Controller : Controller
    {
        private readonly MainContext _context;
            
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
                var CartId = collection["viewBagCart"];
                foreach (var item in collection)
                {
                    if (item.Key.Equals("credit-card-number"))
                    {
                        // Do nothing
                    } else if (item.Key.IndexOf("product") > 0)
                    {
                       // _context.Add();
                    } else if (item.Key.Equals("viewBagCart"))
                    {
                        // updatear Cart con estado pagado
                        //var Cart = _context.Cart.Where(x => x.Id_AspNetUsers == )
                    }
                    Console.WriteLine(item);
                }
                
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
