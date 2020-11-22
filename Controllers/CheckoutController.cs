using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Satish.Helpers;
using Satish.Models;


namespace Satish.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            var connectionId = HttpContext.Connection.Id;
            connectionId = StringTool.Truncate(connectionId, 10);
            int cartId = int.Parse(connectionId);
            ViewBag.cartId = cartId;
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }
    }
}
 