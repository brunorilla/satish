﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Satish.Data;
using Satish.Models;

namespace Satish.Controllers
{
    public class CartProductsController : Controller
    {
        private readonly MainContext _context;

        public CartProductsController(MainContext context)
        {
            _context = context;
        }

        // GET: CartProducts
        public async Task<IActionResult> Index()
        {
            var mainContext = _context.CartProduct.Include(c => c.Cart).Include(c => c.Product);
            return View(await mainContext.ToListAsync());
        }

        // GET: CartProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartProduct = await _context.CartProduct
                .Include(c => c.Cart)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cartProduct == null)
            {
                return NotFound();
            }

            return View(cartProduct);
        }

        // GET: CartProducts/Create
        public IActionResult Create()
        {
            ViewData["CartId"] = new SelectList(_context.Cart, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            return View();
        }

        // POST: CartProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeStamp,CartProductId,CartId,ProductId")] CartProduct cartProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartId"] = new SelectList(_context.Cart, "Id", "Id", cartProduct.CartId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", cartProduct.ProductId);
            return View(cartProduct);
        }

        // GET: CartProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartProduct = await _context.CartProduct.FindAsync(id);
            if (cartProduct == null)
            {
                return NotFound();
            }
            ViewData["CartId"] = new SelectList(_context.Cart, "Id", "Id", cartProduct.CartId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", cartProduct.ProductId);
            return View(cartProduct);
        }

        // POST: CartProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeStamp,CartProductId,CartId,ProductId")] CartProduct cartProduct)
        {
            if (id != cartProduct.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartProductExists(cartProduct.CartId))
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
            ViewData["CartId"] = new SelectList(_context.Cart, "Id", "Id", cartProduct.CartId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", cartProduct.ProductId);
            return View(cartProduct);
        }

        // GET: CartProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartProduct = await _context.CartProduct
                .Include(c => c.Cart)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cartProduct == null)
            {
                return NotFound();
            }

            return View(cartProduct);
        }

        // POST: CartProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartProduct = await _context.CartProduct.FindAsync(id);
            _context.CartProduct.Remove(cartProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartProductExists(int id)
        {
            return _context.CartProduct.Any(e => e.CartId == id);
        }
    }
}
