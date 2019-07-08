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


    [Authorize(Roles = "ShipmentLine")]
    public class ShipmentLineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShipmentLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShipmentLine
        public async Task<IActionResult> Index()
        {
                    var applicationDbContext = _context.ShipmentLine.Include(s => s.branch).Include(s => s.product).Include(s => s.shipment).Include(s => s.warehouse);
                    return View(await applicationDbContext.ToListAsync());
        }        

    // GET: ShipmentLine/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var shipmentLine = await _context.ShipmentLine
                .Include(s => s.branch)
                .Include(s => s.product)
                .Include(s => s.shipment)
                .Include(s => s.warehouse)
                    .SingleOrDefaultAsync(m => m.shipmentLineId == id);
        if (shipmentLine == null)
        {
            return NotFound();
        }

        return View(shipmentLine);
    }


    // GET: ShipmentLine/Create
    public IActionResult Create(string masterid, string id)
    {
        var check = _context.ShipmentLine.SingleOrDefault(m => m.shipmentLineId == id);
        var selected = _context.Shipment.SingleOrDefault(m => m.shipmentId == masterid);
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchId");
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productId");
            ViewData["shipmentId"] = new SelectList(_context.Shipment, "shipmentId", "shipmentId");
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseId");
        if (check == null)
        {
            ShipmentLine objline = new ShipmentLine();
            objline.shipment = selected;
            objline.shipmentId = masterid;
            return View(objline);
        }
        else
        {
            return View(check);
        }
    }




    // POST: ShipmentLine/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("shipmentLineId,shipmentId,branchId,warehouseId,productId,qty,qtyShipment,qtyInventory,createdAt")] ShipmentLine shipmentLine)
    {
        if (ModelState.IsValid)
        {
            _context.Add(shipmentLine);
            await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
                ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchId", shipmentLine.branchId);
                ViewData["productId"] = new SelectList(_context.Product, "productId", "productId", shipmentLine.productId);
                ViewData["shipmentId"] = new SelectList(_context.Shipment, "shipmentId", "shipmentId", shipmentLine.shipmentId);
                ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseId", shipmentLine.warehouseId);
        return View(shipmentLine);
    }

    // GET: ShipmentLine/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var shipmentLine = await _context.ShipmentLine.SingleOrDefaultAsync(m => m.shipmentLineId == id);
        if (shipmentLine == null)
        {
            return NotFound();
        }
                ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchId", shipmentLine.branchId);
                ViewData["productId"] = new SelectList(_context.Product, "productId", "productId", shipmentLine.productId);
                ViewData["shipmentId"] = new SelectList(_context.Shipment, "shipmentId", "shipmentId", shipmentLine.shipmentId);
                ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseId", shipmentLine.warehouseId);
        return View(shipmentLine);
    }

    // POST: ShipmentLine/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("shipmentLineId,shipmentId,branchId,warehouseId,productId,qty,qtyShipment,qtyInventory,createdAt")] ShipmentLine shipmentLine)
    {
        if (id != shipmentLine.shipmentLineId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(shipmentLine);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentLineExists(shipmentLine.shipmentLineId))
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
                ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchId", shipmentLine.branchId);
                ViewData["productId"] = new SelectList(_context.Product, "productId", "productId", shipmentLine.productId);
                ViewData["shipmentId"] = new SelectList(_context.Shipment, "shipmentId", "shipmentId", shipmentLine.shipmentId);
                ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseId", shipmentLine.warehouseId);
        return View(shipmentLine);
    }

    // GET: ShipmentLine/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var shipmentLine = await _context.ShipmentLine
                .Include(s => s.branch)
                .Include(s => s.product)
                .Include(s => s.shipment)
                .Include(s => s.warehouse)
                .SingleOrDefaultAsync(m => m.shipmentLineId == id);
        if (shipmentLine == null)
        {
            return NotFound();
        }

        return View(shipmentLine);
    }




    // POST: ShipmentLine/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var shipmentLine = await _context.ShipmentLine.SingleOrDefaultAsync(m => m.shipmentLineId == id);
            _context.ShipmentLine.Remove(shipmentLine);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ShipmentLineExists(string id)
    {
        return _context.ShipmentLine.Any(e => e.shipmentLineId == id);
    }

  }
}





namespace netcore.MVC
{
  public static partial class Pages
  {
      public static class ShipmentLine
      {
          public const string Controller = "ShipmentLine";
          public const string Action = "Index";
          public const string Role = "ShipmentLine";
          public const string Url = "/ShipmentLine/Index";
          public const string Name = "ShipmentLine";
      }
  }
}
namespace netcore.Models
{
  public partial class ApplicationUser
  {
      [Display(Name = "ShipmentLine")]
      public bool ShipmentLineRole { get; set; } = false;
  }
}



