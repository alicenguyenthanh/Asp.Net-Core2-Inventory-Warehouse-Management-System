using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

using netcore.Data;
using netcore.Models.Invent;

namespace netcore.Controllers.Invent
{


    [Authorize(Roles = "ReceivingLine")]
    public class ReceivingLineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceivingLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReceivingLine
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReceivingLine.Include(r => r.branch).Include(r => r.product).Include(r => r.receiving).Include(r => r.warehouse);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReceivingLine/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receivingLine = await _context.ReceivingLine
                    .Include(r => r.branch)
                    .Include(r => r.product)
                    .Include(r => r.receiving)
                    .Include(r => r.warehouse)
                        .SingleOrDefaultAsync(m => m.receivingLineId == id);
            if (receivingLine == null)
            {
                return NotFound();
            }

            return View(receivingLine);
        }


        // GET: ReceivingLine/Create
        public IActionResult Create(string masterid, string id)
        {
            var check = _context.ReceivingLine.SingleOrDefault(m => m.receivingLineId == id);
            var selected = _context.Receiving.SingleOrDefault(m => m.receivingId == masterid);
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productCode");
            ViewData["receivingId"] = new SelectList(_context.Receiving, "receivingId", "receivingNumber");
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            if (check == null)
            {
                ReceivingLine objline = new ReceivingLine();
                objline.receiving = selected;
                objline.receivingId = masterid;
                return View(objline);
            }
            else
            {
                return View(check);
            }
        }




        // POST: ReceivingLine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("receivingLineId,receivingId,branchId,warehouseId,productId,qty,qtyReceive,qtyInventory,createdAt")] ReceivingLine receivingLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receivingLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName", receivingLine.branchId);
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productCode", receivingLine.productId);
            ViewData["receivingId"] = new SelectList(_context.Receiving, "receivingId", "receivingNumber", receivingLine.receivingId);
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName", receivingLine.warehouseId);
            return View(receivingLine);
        }

        // GET: ReceivingLine/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receivingLine = await _context.ReceivingLine.SingleOrDefaultAsync(m => m.receivingLineId == id);
            if (receivingLine == null)
            {
                return NotFound();
            }
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName", receivingLine.branchId);
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productCode", receivingLine.productId);
            ViewData["receivingId"] = new SelectList(_context.Receiving, "receivingId", "receivingNumber", receivingLine.receivingId);
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName", receivingLine.warehouseId);
            return View(receivingLine);
        }

        // POST: ReceivingLine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("receivingLineId,receivingId,branchId,warehouseId,productId,qty,qtyReceive,qtyInventory,createdAt")] ReceivingLine receivingLine)
        {
            if (id != receivingLine.receivingLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receivingLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceivingLineExists(receivingLine.receivingLineId))
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
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName", receivingLine.branchId);
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productCode", receivingLine.productId);
            ViewData["receivingId"] = new SelectList(_context.Receiving, "receivingId", "receivingNumber", receivingLine.receivingId);
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName", receivingLine.warehouseId);
            return View(receivingLine);
        }

        // GET: ReceivingLine/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receivingLine = await _context.ReceivingLine
                    .Include(r => r.branch)
                    .Include(r => r.product)
                    .Include(r => r.receiving)
                    .Include(r => r.warehouse)
                    .SingleOrDefaultAsync(m => m.receivingLineId == id);
            if (receivingLine == null)
            {
                return NotFound();
            }

            return View(receivingLine);
        }




        // POST: ReceivingLine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var receivingLine = await _context.ReceivingLine.SingleOrDefaultAsync(m => m.receivingLineId == id);
            _context.ReceivingLine.Remove(receivingLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceivingLineExists(string id)
        {
            return _context.ReceivingLine.Any(e => e.receivingLineId == id);
        }

    }
}





namespace netcore.MVC
{
    public static partial class Pages
    {
        public static class ReceivingLine
        {
            public const string Controller = "ReceivingLine";
            public const string Action = "Index";
            public const string Role = "ReceivingLine";
            public const string Url = "/ReceivingLine/Index";
            public const string Name = "ReceivingLine";
        }
    }
}
namespace netcore.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "ReceivingLine")]
        public bool ReceivingLineRole { get; set; } = false;
    }
}



