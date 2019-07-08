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


    [Authorize(Roles = "PurchaseOrderLine")]
    public class PurchaseOrderLineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrderLine
        public async Task<IActionResult> Index()
        {
                    var applicationDbContext = _context.PurchaseOrderLine.Include(p => p.product).Include(p => p.purchaseOrder);
                    return View(await applicationDbContext.ToListAsync());
        }        

    // GET: PurchaseOrderLine/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var purchaseOrderLine = await _context.PurchaseOrderLine
                .Include(p => p.product)
                .Include(p => p.purchaseOrder)
                    .SingleOrDefaultAsync(m => m.purchaseOrderLineId == id);
        if (purchaseOrderLine == null)
        {
            return NotFound();
        }

        return View(purchaseOrderLine);
    }


    // GET: PurchaseOrderLine/Create
    public IActionResult Create(string masterid, string id)
    {
        var check = _context.PurchaseOrderLine.SingleOrDefault(m => m.purchaseOrderLineId == id);
        var selected = _context.PurchaseOrder.SingleOrDefault(m => m.purchaseOrderId == masterid);
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productCode");
            ViewData["purchaseOrderId"] = new SelectList(_context.PurchaseOrder, "purchaseOrderId", "purchaseOrderId");
        if (check == null)
        {
            PurchaseOrderLine objline = new PurchaseOrderLine();
            objline.purchaseOrder = selected;
            objline.purchaseOrderId = masterid;
            return View(objline);
        }
        else
        {
            return View(check);
        }
    }




    // POST: PurchaseOrderLine/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("purchaseOrderLineId,purchaseOrderId,productId,qty,price,discountAmount,totalAmount,createdAt")] PurchaseOrderLine purchaseOrderLine)
    {
        if (ModelState.IsValid)
        {
            _context.Add(purchaseOrderLine);
            await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
                ViewData["productId"] = new SelectList(_context.Product, "productId", "productId", purchaseOrderLine.productId);
                ViewData["purchaseOrderId"] = new SelectList(_context.PurchaseOrder, "purchaseOrderId", "purchaseOrderId", purchaseOrderLine.purchaseOrderId);
        return View(purchaseOrderLine);
    }

    // GET: PurchaseOrderLine/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var purchaseOrderLine = await _context.PurchaseOrderLine.SingleOrDefaultAsync(m => m.purchaseOrderLineId == id);
        if (purchaseOrderLine == null)
        {
            return NotFound();
        }
                ViewData["productId"] = new SelectList(_context.Product, "productId", "productId", purchaseOrderLine.productId);
                ViewData["purchaseOrderId"] = new SelectList(_context.PurchaseOrder, "purchaseOrderId", "purchaseOrderId", purchaseOrderLine.purchaseOrderId);
        return View(purchaseOrderLine);
    }

    // POST: PurchaseOrderLine/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("purchaseOrderLineId,purchaseOrderId,productId,qty,price,discountAmount,totalAmount,createdAt")] PurchaseOrderLine purchaseOrderLine)
    {
        if (id != purchaseOrderLine.purchaseOrderLineId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(purchaseOrderLine);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderLineExists(purchaseOrderLine.purchaseOrderLineId))
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
                ViewData["productId"] = new SelectList(_context.Product, "productId", "productId", purchaseOrderLine.productId);
                ViewData["purchaseOrderId"] = new SelectList(_context.PurchaseOrder, "purchaseOrderId", "purchaseOrderId", purchaseOrderLine.purchaseOrderId);
        return View(purchaseOrderLine);
    }

    // GET: PurchaseOrderLine/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var purchaseOrderLine = await _context.PurchaseOrderLine
                .Include(p => p.product)
                .Include(p => p.purchaseOrder)
                .SingleOrDefaultAsync(m => m.purchaseOrderLineId == id);
        if (purchaseOrderLine == null)
        {
            return NotFound();
        }

        return View(purchaseOrderLine);
    }




    // POST: PurchaseOrderLine/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var purchaseOrderLine = await _context.PurchaseOrderLine.SingleOrDefaultAsync(m => m.purchaseOrderLineId == id);
            _context.PurchaseOrderLine.Remove(purchaseOrderLine);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PurchaseOrderLineExists(string id)
    {
        return _context.PurchaseOrderLine.Any(e => e.purchaseOrderLineId == id);
    }

  }
}





namespace netcore.MVC
{
  public static partial class Pages
  {
      public static class PurchaseOrderLine
      {
          public const string Controller = "PurchaseOrderLine";
          public const string Action = "Index";
          public const string Role = "PurchaseOrderLine";
          public const string Url = "/PurchaseOrderLine/Index";
          public const string Name = "PurchaseOrderLine";
      }
  }
}
namespace netcore.Models
{
  public partial class ApplicationUser
  {
      [Display(Name = "PurchaseOrderLine")]
      public bool PurchaseOrderLineRole { get; set; } = false;
  }
}



