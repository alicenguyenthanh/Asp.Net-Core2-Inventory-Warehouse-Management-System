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


    [Authorize(Roles = "Receiving")]
    public class ReceivingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceivingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GetWarehouseByOrder(string purchaseOrderId)
        {
            PurchaseOrder po = _context.PurchaseOrder
                .Include(x => x.branch)
                .Where(x => x.purchaseOrderId.Equals(purchaseOrderId)).FirstOrDefault();

            List<Warehouse> warehouseList = _context.Warehouse.Where(x => x.branchId.Equals(po.branch.branchId)).ToList();
            warehouseList.Insert(0, new Warehouse { warehouseId = "0", warehouseName = "Select" });

            return Json(new SelectList(warehouseList, "warehouseId", "warehouseName"));
        }

        public async Task<IActionResult> ShowGSRN(string id)
        {
            Receiving obj = await _context.Receiving
                .Include(x => x.vendor)
                .Include(x => x.purchaseOrder)
                    .ThenInclude(x => x.branch)
                .Include(x => x.receivingLine).ThenInclude(x => x.product)
                .SingleOrDefaultAsync(x => x.receivingId.Equals(id));
            return View(obj);
        }

        public async Task<IActionResult> PrintGSRN(string id)
        {
            Receiving obj = await _context.Receiving
                .Include(x => x.vendor)
                .Include(x => x.purchaseOrder)
                    .ThenInclude(x => x.branch)
                .Include(x => x.receivingLine).ThenInclude(x => x.product)
                .SingleOrDefaultAsync(x => x.receivingId.Equals(id));
            return View(obj);
        }

        // GET: Receiving
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Receiving.OrderByDescending(x => x.createdAt).Include(r => r.branch).Include(r => r.purchaseOrder).Include(r => r.vendor).Include(r => r.warehouse);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Receiving/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiving = await _context.Receiving
                    .Include(r => r.branch)
                    .Include(r => r.purchaseOrder)
                    .Include(r => r.vendor)
                    .Include(r => r.warehouse)
                        .SingleOrDefaultAsync(m => m.receivingId == id);
            if (receiving == null)
            {
                return NotFound();
            }

            return View(receiving);
        }


        // GET: Receiving/Create
        public IActionResult Create()
        {
            ViewData["StatusMessage"] = TempData["StatusMessage"];
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName");
            List<PurchaseOrder> poList = _context.PurchaseOrder.Where(x => x.purchaseOrderStatus == PurchaseOrderStatus.Open).ToList();
            poList.Insert(0, new PurchaseOrder { purchaseOrderId = "0", purchaseOrderNumber = "Select" });
            ViewData["purchaseOrderId"] = new SelectList(poList, "purchaseOrderId", "purchaseOrderNumber");
            ViewData["vendorId"] = new SelectList(_context.Vendor, "vendorId", "vendorName");
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            Receiving rcv = new Receiving();
            return View(rcv);
        }




        // POST: Receiving/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("receivingId,purchaseOrderId,receivingNumber,receivingDate,vendorId,vendorDO,vendorInvoice,branchId,warehouseId,HasChild,createdAt")] Receiving receiving)
        {
            if (receiving.purchaseOrderId == "0" || receiving.warehouseId == "0")
            {
                TempData["StatusMessage"] = "Error. Purchase order or warehouse is not valid. Please select valid purchase order and warehouse";
                return RedirectToAction(nameof(Create));
            }

            if (ModelState.IsValid)
            {
                //check receiving
                Receiving check = await _context.Receiving.SingleOrDefaultAsync(x => x.purchaseOrderId.Equals(receiving.purchaseOrderId));
                if (check != null)
                {
                    ViewData["StatusMessage"] = "Error. Purchase order already received. " + check.receivingNumber;

                    ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName");
                    ViewData["purchaseOrderId"] = new SelectList(_context.PurchaseOrder, "purchaseOrderId", "purchaseOrderNumber");
                    ViewData["vendorId"] = new SelectList(_context.Vendor, "vendorId", "vendorName");
                    ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");

                    return View(receiving);
                }
                receiving.warehouse = await _context.Warehouse.Include(x => x.branch).SingleOrDefaultAsync(x => x.warehouseId.Equals(receiving.warehouseId));
                receiving.branch = receiving.warehouse.branch;
                receiving.purchaseOrder = await _context.PurchaseOrder.Include(x => x.vendor).SingleOrDefaultAsync(x => x.purchaseOrderId.Equals(receiving.purchaseOrderId));
                receiving.vendor = receiving.purchaseOrder.vendor;

                _context.Add(receiving);

                //change status of purchase order to completed
                receiving.purchaseOrder.purchaseOrderStatus = PurchaseOrderStatus.Completed;
                _context.PurchaseOrder.Update(receiving.purchaseOrder);

                await _context.SaveChangesAsync();

                //auto create receiving line, full receive
                List<PurchaseOrderLine> polines = new List<PurchaseOrderLine>();
                polines = _context.PurchaseOrderLine.Include(x => x.product).Where(x => x.purchaseOrderId.Equals(receiving.purchaseOrderId)).ToList();
                foreach (var item in polines)
                {
                    ReceivingLine line = new ReceivingLine();
                    line.receiving = receiving;
                    line.product = item.product;
                    line.qty = item.qty;
                    line.qtyReceive = item.qty;
                    line.qtyInventory = line.qtyReceive * 1;
                    line.branchId = receiving.branchId;
                    line.warehouseId = receiving.warehouseId;

                    _context.ReceivingLine.Add(line);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Details), new { id = receiving.receivingId });
            }
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName", receiving.branchId);
            ViewData["purchaseOrderId"] = new SelectList(_context.PurchaseOrder, "purchaseOrderId", "purchaseOrderNumber", receiving.purchaseOrderId);
            ViewData["vendorId"] = new SelectList(_context.Vendor, "vendorId", "vendorName", receiving.vendorId);
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName", receiving.warehouseId);
            return View(receiving);
        }

        // GET: Receiving/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiving = await _context.Receiving.SingleOrDefaultAsync(m => m.receivingId == id);
            if (receiving == null)
            {
                return NotFound();
            }
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName", receiving.branchId);
            ViewData["purchaseOrderId"] = new SelectList(_context.PurchaseOrder, "purchaseOrderId", "purchaseOrderNumber", receiving.purchaseOrderId);
            ViewData["vendorId"] = new SelectList(_context.Vendor, "vendorId", "vendorName", receiving.vendorId);
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName", receiving.warehouseId);
            return View(receiving);
        }

        // POST: Receiving/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("receivingId,purchaseOrderId,receivingNumber,receivingDate,vendorId,vendorDO,vendorInvoice,branchId,warehouseId,HasChild,createdAt")] Receiving receiving)
        {
            if (id != receiving.receivingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceivingExists(receiving.receivingId))
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
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName", receiving.branchId);
            ViewData["purchaseOrderId"] = new SelectList(_context.PurchaseOrder, "purchaseOrderId", "purchaseOrderNumber", receiving.purchaseOrderId);
            ViewData["vendorId"] = new SelectList(_context.Vendor, "vendorId", "vendorName", receiving.vendorId);
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName", receiving.warehouseId);
            return View(receiving);
        }

        // GET: Receiving/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiving = await _context.Receiving
                    .Include(r => r.branch)
                    .Include(r => r.purchaseOrder)
                    .Include(r => r.vendor)
                    .Include(r => r.warehouse)
                    .SingleOrDefaultAsync(m => m.receivingId == id);
            if (receiving == null)
            {
                return NotFound();
            }

            return View(receiving);
        }




        // POST: Receiving/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var receiving = await _context.Receiving
                .Include(x => x.receivingLine)
                .Include(x => x.purchaseOrder)
                .SingleOrDefaultAsync(m => m.receivingId == id);
            try
            {
                _context.ReceivingLine.RemoveRange(receiving.receivingLine);
                _context.Receiving.Remove(receiving);

                //rollback status to open
                receiving.purchaseOrder.purchaseOrderStatus = PurchaseOrderStatus.Open;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return View(receiving);
            }
            
        }

        private bool ReceivingExists(string id)
        {
            return _context.Receiving.Any(e => e.receivingId == id);
        }

    }
}





namespace netcore.MVC
{
    public static partial class Pages
    {
        public static class Receiving
        {
            public const string Controller = "Receiving";
            public const string Action = "Index";
            public const string Role = "Receiving";
            public const string Url = "/Receiving/Index";
            public const string Name = "Receiving";
        }
    }
}
namespace netcore.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Receiving")]
        public bool ReceivingRole { get; set; } = false;
    }
}



