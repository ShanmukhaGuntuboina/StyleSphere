using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;

namespace StyleSphere.Controllers
{
    public class OrdersDatumsController : Controller
    {
        private readonly StyleSphereDbContext _context;

        public OrdersDatumsController(StyleSphereDbContext context)
        {
            _context = context;
        }

        // GET: OrdersDatums
        public async Task<IActionResult> Index()
        {
            var styleSphereDbContext = _context.OrdersData.Include(o => o.Customer);
            return View(await styleSphereDbContext.ToListAsync());
        }

        // GET: OrdersDatums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdersData == null)
            {
                return NotFound();
            }

            var ordersDatum = await _context.OrdersData
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (ordersDatum == null)
            {
                return NotFound();
            }

            return View(ordersDatum);
        }

        // GET: OrdersDatums/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            return View();
        }

        // POST: OrdersDatums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,OrderDate,ShippingAddress,BillingAddress,TrackingId,NetAmount,ActiveStatus")] OrdersDatum ordersDatum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordersDatum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", ordersDatum.CustomerId);
            return View(ordersDatum);
        }

        // GET: OrdersDatums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdersData == null)
            {
                return NotFound();
            }

            var ordersDatum = await _context.OrdersData.FindAsync(id);
            if (ordersDatum == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", ordersDatum.CustomerId);
            return View(ordersDatum);
        }

        // POST: OrdersDatums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,OrderDate,ShippingAddress,BillingAddress,TrackingId,NetAmount,ActiveStatus")] OrdersDatum ordersDatum)
        {
            if (id != ordersDatum.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordersDatum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersDatumExists(ordersDatum.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", ordersDatum.CustomerId);
            return View(ordersDatum);
        }

        // GET: OrdersDatums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdersData == null)
            {
                return NotFound();
            }

            var ordersDatum = await _context.OrdersData
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (ordersDatum == null)
            {
                return NotFound();
            }

            return View(ordersDatum);
        }

        // POST: OrdersDatums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdersData == null)
            {
                return Problem("Entity set 'StyleSphereDbContext.OrdersData'  is null.");
            }
            var ordersDatum = await _context.OrdersData.FindAsync(id);
            if (ordersDatum != null)
            {
                _context.OrdersData.Remove(ordersDatum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersDatumExists(int id)
        {
          return _context.OrdersData.Any(e => e.OrderId == id);
        }
    }
}
