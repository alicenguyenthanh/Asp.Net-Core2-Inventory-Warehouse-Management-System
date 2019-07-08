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


    [Authorize(Roles = "TransferIn")]
    public class TransferInController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransferInController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ShowTransferIn(string id)
        {
            TransferIn obj = await _context.TransferIn
                .Include(x => x.transferOrder)
                .Include(x => x.warehouseFrom)
                .Include(x => x.warehouseTo)
                .Include(x => x.transferInLine).ThenInclude(x => x.product)
                .SingleOrDefaultAsync(x => x.transferInId.Equals(id));


            return View(obj);
        }

        public async Task<IActionResult> PrintTransferIn(string id)
        {
            TransferIn obj = await _context.TransferIn
                .Include(x => x.transferOrder)
                .Include(x => x.warehouseFrom)
                .Include(x => x.warehouseTo)
                .Include(x => x.transferInLine).ThenInclude(x => x.product)
                .SingleOrDefaultAsync(x => x.transferInId.Equals(id));

            return View(obj);
        }

        // GET: TransferIn
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TransferIn.OrderByDescending(x => x.createdAt).Include(t => t.transferOrder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TransferIn/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferIn = await _context.TransferIn
                    .Include(x => x.branchFrom)
                    .Include(x => x.branchTo)
                    .Include(x => x.warehouseFrom)
                    .Include(x => x.warehouseTo)
                    .Include(t => t.transferOrder)
                        .SingleOrDefaultAsync(m => m.transferInId == id);
            if (transferIn == null)
            {
                return NotFound();
            }

            return View(transferIn);
        }


        // GET: TransferIn/Create
        public IActionResult Create()
        {
            ViewData["transferOrderId"] = new SelectList(_context.TransferOrder.Where(x => x.transferOrderStatus == TransferOrderStatus.Open && x.isIssued == true).ToList(), "transferOrderId", "transferOrderNumber");
            ViewData["branchIdFrom"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdFrom"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            ViewData["branchIdTo"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdTo"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            TransferIn obj = new TransferIn();
            return View(obj);
        }




        // POST: TransferIn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("transferInId,transferOrderId,transferInNumber,transferInDate,description,branchIdFrom,warehouseIdFrom,branchIdTo,warehouseIdTo,HasChild,createdAt")] TransferIn transferIn)
        {
            if (ModelState.IsValid)
            {

                //check transfer order
                TransferIn check = await _context.TransferIn.SingleOrDefaultAsync(x => x.transferOrderId.Equals(transferIn.transferOrderId));
                if (check != null)
                {
                    ViewData["StatusMessage"] = "Error. Transfer order already received. " + check.transferInNumber;

                    ViewData["transferOrderId"] = new SelectList(_context.TransferOrder, "transferOrderId", "transferOrderNumber");
                    ViewData["branchIdFrom"] = new SelectList(_context.Branch, "branchId", "branchName");
                    ViewData["warehouseIdFrom"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
                    ViewData["branchIdTo"] = new SelectList(_context.Branch, "branchId", "branchName");
                    ViewData["warehouseIdTo"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");


                    return View(transferIn);
                }

                TransferOrder to = await _context.TransferOrder.Where(x => x.transferOrderId.Equals(transferIn.transferOrderId)).FirstOrDefaultAsync();
                transferIn.warehouseIdFrom = to.warehouseIdFrom;
                transferIn.warehouseIdTo = to.warehouseIdTo;

                transferIn.warehouseFrom = await _context.Warehouse.Include(x => x.branch).SingleOrDefaultAsync(x => x.warehouseId.Equals(transferIn.warehouseIdFrom));
                transferIn.branchFrom = transferIn.warehouseFrom.branch;
                transferIn.warehouseTo = await _context.Warehouse.Include(x => x.branch).SingleOrDefaultAsync(x => x.warehouseId.Equals(transferIn.warehouseIdTo));
                transferIn.branchTo = transferIn.warehouseTo.branch;


                to.isReceived = true;
                to.transferOrderStatus = TransferOrderStatus.Completed;

                _context.Add(transferIn);
                await _context.SaveChangesAsync();

                //auto create transfer in line, full shipment
                List<TransferOrderLine> lines = new List<TransferOrderLine>();
                lines = _context.TransferOrderLine.Include(x => x.product).Where(x => x.transferOrderId.Equals(transferIn.transferOrderId)).ToList();
                foreach (var item in lines)
                {
                    TransferInLine line = new TransferInLine();
                    line.transferIn = transferIn;
                    line.product = item.product;
                    line.qty = item.qty;
                    line.qtyInventory = line.qty * 1;

                    _context.TransferInLine.Add(line);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Details), new { id = transferIn.transferInId });
            }
            ViewData["transferOrderId"] = new SelectList(_context.TransferOrder, "transferOrderId", "transferOrderNumber", transferIn.transferOrderId);
            return View(transferIn);
        }

        // GET: TransferIn/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferIn = await _context.TransferIn
                .Include(x => x.branchFrom)
                .Include(x => x.branchTo)
                .Include(x => x.warehouseFrom)
                .Include(x => x.warehouseTo)
                .SingleOrDefaultAsync(m => m.transferInId == id);
            if (transferIn == null)
            {
                return NotFound();
            }
            ViewData["transferOrderId"] = new SelectList(_context.TransferOrder, "transferOrderId", "transferOrderNumber", transferIn.transferOrderId);
            ViewData["branchIdFrom"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdFrom"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            ViewData["branchIdTo"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdTo"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            return View(transferIn);
        }

        // POST: TransferIn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("transferInId,transferOrderId,transferInNumber,transferInDate,description,branchIdFrom,warehouseIdFrom,branchIdTo,warehouseIdTo,HasChild,createdAt")] TransferIn transferIn)
        {
            if (id != transferIn.transferInId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transferIn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransferInExists(transferIn.transferInId))
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
            ViewData["transferOrderId"] = new SelectList(_context.TransferOrder, "transferOrderId", "transferOrderNumber", transferIn.transferOrderId);
            ViewData["branchIdFrom"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdFrom"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            ViewData["branchIdTo"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdTo"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            return View(transferIn);
        }

        // GET: TransferIn/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferIn = await _context.TransferIn
                    .Include(x => x.branchFrom)
                    .Include(x => x.branchTo)
                    .Include(x => x.warehouseFrom)
                    .Include(x => x.warehouseTo)
                    .Include(t => t.transferOrder)
                    .SingleOrDefaultAsync(m => m.transferInId == id);
            if (transferIn == null)
            {
                return NotFound();
            }

            return View(transferIn);
        }




        // POST: TransferIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transferIn = await _context.TransferIn
                .Include(x => x.transferInLine)
                .Include(x => x.transferOrder)
                .SingleOrDefaultAsync(m => m.transferInId == id);
            try
            {
                _context.TransferInLine.RemoveRange(transferIn.transferInLine);
                _context.TransferIn.Remove(transferIn);
                transferIn.transferOrder.transferOrderStatus = TransferOrderStatus.Open;
                transferIn.transferOrder.isReceived = false;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return View(transferIn);
            }
            
        }

        private bool TransferInExists(string id)
        {
            return _context.TransferIn.Any(e => e.transferInId == id);
        }

    }
}





namespace netcore.MVC
{
    public static partial class Pages
    {
        public static class TransferIn
        {
            public const string Controller = "TransferIn";
            public const string Action = "Index";
            public const string Role = "TransferIn";
            public const string Url = "/TransferIn/Index";
            public const string Name = "TransferIn";
        }
    }
}
namespace netcore.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "TransferIn")]
        public bool TransferInRole { get; set; } = false;
    }
}



