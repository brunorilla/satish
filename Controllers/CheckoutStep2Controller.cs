using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using Satish.Models;
using Satish.Data;


namespace Satish.Controllers
{
    public class CheckoutStep2Controller : Controller
    {
        private readonly MainContext _context;

        public CheckoutStep2Controller(MainContext context)
        {
            _context = context;
        }

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
        public async Task<ActionResult> CreateAsync(IFormCollection collection)
        {
            try
            {
                int cartId_AspNetUsers = 0;
                var CartId = collection["viewBagCart"];
                foreach (var item in collection)
                {
                    if (item.Key.Contains("product"))
                    {
                        var tempProdId = item.Value;


                        CartProduct cartprod = new CartProduct
                        {
                            CartId = cartId_AspNetUsers,
                            ProductId = tempProdId,
                            TimeStamp = DateTime.Now
                        };
                        Console.WriteLine(cartprod);
                        _context.Add(cartprod);
                        var changesmade = _context.SaveChanges();
                        
                    }
                    else if (item.Key.Equals("viewBagCart"))
                    {
                        var idString = item.Value;

                        int.TryParse(idString, out cartId_AspNetUsers);
                        var entity = _context.Cart.FirstOrDefault(item => item.Id_AspNetUsers == cartId_AspNetUsers);
                        if (entity != null)
                        {
                            entity.estado = true;
                            var changesmade2 = _context.SaveChanges();
                        }
                    }
                }

                ViewData["cartid"] = cartId_AspNetUsers;
                
                return RedirectToAction(nameof(Index),ViewData);
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