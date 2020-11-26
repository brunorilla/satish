using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Satish.Data;
using Satish.Helpers;
using Satish.Models;

namespace Satish.Controllers
{
    public class CartController : Controller
    {
        private readonly MainContext _context;

        public CartController(MainContext context)
        {
            _context = context;
        }

        // GET: Cart
        /*
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cart.ToListAsync());
        }
        */
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();

        }


        // GET: Cart/Buy/5

        public async Task<IActionResult> Buy(string id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
                cart.Add(new Item
                {
                    Product = product,
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    var product = await _context.Product
                    .FirstOrDefaultAsync(m => m.Id == id);
                    cart.Add(new Item
                    {
                        Product = product,
                        Quantity = 1
                    });

                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }


        public IActionResult Remove(string id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = IsExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }



        private int IsExist(string id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }                    
            }
            return -1;
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_AspNetUsers,estado,Date,Price")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromCheckout([Bind("Id_AspNetUsers,Price")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                cart.estado = false;
                cart.Date = DateTime.Now;
                _context.Add(cart);
                await _context.SaveChangesAsync();
                List<CartProduct> cartProductsList = new List<CartProduct>();
                List<Item> completeCartFromJson = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                
                
                foreach (var prod in completeCartFromJson)
                {
                    Product auxProduct = new Product
                    {
                        Id = prod.Product.Id,
                    };
                    Cart auxCart = new Cart
                    {
                        Id_AspNetUsers = cart.Id_AspNetUsers
                    };
                    CartProduct auxCartProduct = new CartProduct
                    {
                        ProductId = auxProduct.Id,
                        CartId = auxCart.Id_AspNetUsers
                    };
                    cartProductsList.Add(auxCartProduct);
                }
                
                Cart data = new Cart
                {
                    Id_AspNetUsers = cart.Id_AspNetUsers,
                    Price = cart.Price,
                    estado = cart.estado,
                    Date = cart.Date
                  
                };
                Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary tempData = TempData;
                
                ViewDataHelper.Put(tempData, "cart",data);
                ViewDataHelper.Put(tempData,"cartProduct",cartProductsList);

                return RedirectToAction("Index", "CheckoutStep1");
            }
            return View("../Checkout/Index");
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_AspNetUsers,estado,Date,Price")] Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }
    }

}
