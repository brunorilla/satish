using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Satish.Models;
using Newtonsoft.Json;
using Satish.Helpers;


namespace Satish.Controllers
{
    public class CheckoutStep1Controller : Controller
    {
        // GET: CheckoutStep1Controller
        public ActionResult Index()
            
        {
            Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary tempData = TempData;
            Cart cartData = (Cart) ViewDataHelper.Get<Cart>(tempData, "cart");
            CartProduct cartProductData = (CartProduct)ViewDataHelper.Get<CartProduct>(tempData, "cartProduct");
            ViewBag.cart = cartData;
            ViewBag.cartProduct = cartProductData;

            
            return View();
        }

        // GET: CheckoutStep1Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CheckoutStep1Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckoutStep1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CheckoutStep1Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckoutStep1Controller/Edit/5
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

        // GET: CheckoutStep1Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckoutStep1Controller/Delete/5
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
