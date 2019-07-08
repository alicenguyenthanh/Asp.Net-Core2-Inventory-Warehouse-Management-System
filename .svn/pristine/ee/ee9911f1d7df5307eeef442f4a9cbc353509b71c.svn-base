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


    [Authorize(Roles = "TransferOrder")]
    public class TransferOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransferOrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ShowTransferOrder(string id)
        {
            TransferOrder obj = await _context.TransferOrder
                .Include(x => x.warehouseFrom)
                .Include(x => x.warehouseTo)
                .Include(x => x.transferOrderLine).ThenInclude(x => x.product)
                .SingleOrDefaultAsync(x => x.transferOrderId.Equals(id));
            

            return View(obj);
        }

        public async Task<IActionResult> PrintTransferOrder(string id)
        {
            TransferOrder obj = await _context.TransferOrder
                .Include(x => x.warehouseFrom)
                .Include(x => x.warehouseTo)
                .Include(x => x.transferOrderLine).ThenInclude(x => x.product)
                .SingleOrDefaultAsync(x => x.transferOrderId.Equals(id));
            return View(obj);
        }

        // GET: TransferOrder
        public async Task<IActionResult> Index()
        {
            List<TransferOrder> lists = new List<TransferOrder>();
            lists = await _context.TransferOrder.OrderByDescending(x => x.createdAt)
                .Include(x => x.branchFrom)
                .Include(x => x.branchTo)
                .Include(x => x.warehouseFrom)
                .Include(x => x.warehouseTo)
                .ToListAsync();
            return View(lists);
        }

        // GET: TransferOrder/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferOrder = await _context.TransferOrder
                        .Include(x => x.branchFrom)
                        .Include(x => x.branchTo)
                        .Include(x => x.warehouseFrom)
                        .Include(x => x.warehouseTo)
                        .SingleOrDefaultAsync(m => m.transferOrderId == id);
            if (transferOrder == null)
            {
                return NotFound();
            }

            return View(transferOrder);
        }


        // GET: TransferOrder/Create
        public IActionResult Create()
        {
            ViewData["StatusMessage"] = TempData["StatusMessage"];
            ViewData["branchIdFrom"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdFrom"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            ViewData["branchIdTo"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdTo"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            TransferOrder obj = new TransferOrder();
            return View(obj);
        }




        // POST: TransferOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("transferOrderId,transferOrderStatus,transferOrderNumber,transferOrderDate,description,picName,branchIdFrom,warehouseIdFrom,branchIdTo,warehouseIdTo,HasChild,createdAt")] TransferOrder transferOrder)
        {
            if (transferOrder.warehouseIdFrom == transferOrder.warehouseIdTo)
            {
                TempData["StatusMessage"] = "Error. Warehouse from and to are the same. Transfer order only working if from and to warehouse are different";
                return RedirectToAction(nameof(Create));
            }

            if (ModelState.IsValid)
            {
                transferOrder.warehouseFrom = await _context.Warehouse.Include(x => x.branch).SingleOrDefaultAsync(x => x.warehouseId.Equals(transferOrder.warehouseIdFrom));
                transferOrder.branchFrom = transferOrder.warehouseFrom.branch;

                transferOrder.warehouseTo = await _context.Warehouse.SingleOrDefaultAsync(x => x.warehouseId.Equals(transferOrder.warehouseIdTo));
                transferOrder.branchTo = transferOrder.warehouseTo.branch;
                

                _context.Add(transferOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = transferOrder.transferOrderId });
            }
            return View(transferOrder);
        }

        // GET: TransferOrder/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferOrder = await _context.TransferOrder.SingleOrDefaultAsync(m => m.transferOrderId == id);
            if (transferOrder == null)
            {
                return NotFound();
            }
            ViewData["branchIdFrom"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdFrom"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            ViewData["branchIdTo"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdTo"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            TempData["TransferOrderStatus"] = transferOrder.transferOrderStatus;
            ViewData["StatusMessage"] = TempData["StatusMessage"];
            return View(transferOrder);
        }

        // POST: TransferOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("transferOrderId,isIssued,isReceived,transferOrderStatus,transferOrderNumber,transferOrderDate,description,picName,branchIdFrom,warehouseIdFrom,branchIdTo,warehouseIdTo,HasChild,createdAt")] TransferOrder transferOrder)
        {
            if (id != transferOrder.transferOrderId)
            {
                return NotFound();
            }

            if ((TransferOrderStatus)TempData["TransferOrderStatus"] == TransferOrderStatus.Completed)
            {
                TempData["StatusMessage"] = "Error. Can not edit [Completed] order.";
                return RedirectToAction(nameof(Edit), new { id = transferOrder.transferOrderId });
            }

            if (transferOrder.transferOrderStatus == TransferOrderStatus.Completed)
            {
                TempData["StatusMessage"] = "Error. Can not edit status to [Completed].";
                return RedirectToAction(nameof(Edit), new { id = transferOrder.transferOrderId });
            }

            if (transferOrder.isIssued == true
                || transferOrder.isReceived == true)
            {
                TempData["StatusMessage"] = "Error. Can not edit [Open] order that already process the goods issue or goods receive.";
                return RedirectToAction(nameof(Edit), new { id = transferOrder.transferOrderId });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    transferOrder.warehouseFrom = await _context.Warehouse.Include(x => x.branch).SingleOrDefaultAsync(x => x.warehouseId.Equals(transferOrder.warehouseIdFrom));
                    transferOrder.branchFrom = transferOrder.warehouseFrom.branch;

                    transferOrder.warehouseTo = await _context.Warehouse.SingleOrDefaultAsync(x => x.warehouseId.Equals(transferOrder.warehouseIdTo));
                    transferOrder.branchTo = transferOrder.warehouseTo.branch;

                    _context.Update(transferOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransferOrderExists(transferOrder.transferOrderId))
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
            return View(transferOrder);
        }

        // GET: TransferOrder/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferOrder = await _context.TransferOrder
                    .Include(x => x.branchFrom)
                    .Include(x => x.branchTo)
                    .Include(x => x.warehouseFrom)
                    .Include(x => x.warehouseTo)
                    .SingleOrDefaultAsync(m => m.transferOrderId == id);
            if (transferOrder == null)
            {
                return NotFound();
            }

            return View(transferOrder);
        }




        // POST: TransferOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transferOrder = await _context.TransferOrder
                .Include(x => x.transferOrderLine)
                .SingleOrDefaultAsync(m => m.transferOrderId == id);
            try
            {
                _context.TransferOrderLine.RemoveRange(transferOrder.transferOrderLine);
                _context.TransferOrder.Remove(transferOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return View(transferOrder);
            }
            
        }

        private bool TransferOrderExists(string id)
        {
            return _context.TransferOrder.Any(e => e.transferOrderId == id);
        }

    }
}





namespace netcore.MVC
{
    public static partial class Pages
    {
        public static class TransferOrder
        {
            public const string Controller = "TransferOrder";
            public const string Action = "Index";
            public const string Role = "TransferOrder";
            public const string Url = "/TransferOrder/Index";
            public const string Name = "TransferOrder";
        }
    }
}
namespace netcore.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "TransferOrder")]
        public bool TransferOrderRole { get; set; } = false;
    }
}



