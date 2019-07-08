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
using netcore.Services;

namespace netcore.Controllers.Invent
{


    [Authorize(Roles = "TransferOut")]
    public class TransferOutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INetcoreService _netcoreService;

        public TransferOutController(ApplicationDbContext context, INetcoreService netcoreService)
        {
            _context = context;
            _netcoreService = netcoreService;
        }

        public async Task<IActionResult> ShowTransferOut(string id)
        {
            TransferOut obj = await _context.TransferOut
                .Include(x => x.transferOrder)
                .Include(x => x.warehouseFrom)
                .Include(x => x.warehouseTo)
                .Include(x => x.transferOutLine).ThenInclude(x => x.product)
                .SingleOrDefaultAsync(x => x.transferOutId.Equals(id));
           

            return View(obj);
        }

        public async Task<IActionResult> PrintTransferOut(string id)
        {
            TransferOut obj = await _context.TransferOut
                .Include(x => x.transferOrder)
                .Include(x => x.warehouseFrom)
                .Include(x => x.warehouseTo)
                .Include(x => x.transferOutLine).ThenInclude(x => x.product)
                .SingleOrDefaultAsync(x => x.transferOutId.Equals(id));

            return View(obj);
        }

        // GET: TransferOut
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TransferOut.OrderByDescending(x => x.createdAt).Include(t => t.transferOrder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TransferOut/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferOut = await _context.TransferOut
                    .Include(x => x.branchFrom)
                    .Include(x => x.branchTo)
                    .Include(x => x.warehouseFrom)
                    .Include(x => x.warehouseTo)
                    .Include(t => t.transferOrder)
                        .SingleOrDefaultAsync(m => m.transferOutId == id);
            if (transferOut == null)
            {
                return NotFound();
            }

            return View(transferOut);
        }


        // GET: TransferOut/Create
        public IActionResult Create()
        {
            ViewData["StatusMessage"] = TempData["StatusMessage"];
            ViewData["transferOrderId"] = new SelectList(_context.TransferOrder.Where(x => x.transferOrderStatus == TransferOrderStatus.Open && x.isIssued == false).ToList(), "transferOrderId", "transferOrderNumber");
            ViewData["branchIdFrom"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdFrom"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            ViewData["branchIdTo"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdTo"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            TransferOut to = new TransferOut();
            return View(to);
        }




        // POST: TransferOut/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("transferOutId,transferOrderId,transferOutNumber,transferOutDate,description,branchIdFrom,warehouseIdFrom,branchIdTo,warehouseIdTo,HasChild,createdAt")] TransferOut transferOut)
        {
            if (ModelState.IsValid)
            {

                //check transfer order
                TransferOut check = await _context.TransferOut
                    .Include(x => x.transferOrder)
                    .SingleOrDefaultAsync(x => x.transferOrderId.Equals(transferOut.transferOrderId));
                if (check != null)
                {
                    ViewData["StatusMessage"] = "Error. Transfer order already issued. " + check.transferOutNumber;

                    ViewData["transferOrderId"] = new SelectList(_context.TransferOrder, "transferOrderId", "transferOrderNumber");
                    ViewData["branchIdFrom"] = new SelectList(_context.Branch, "branchId", "branchName");
                    ViewData["warehouseIdFrom"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
                    ViewData["branchIdTo"] = new SelectList(_context.Branch, "branchId", "branchName");
                    ViewData["warehouseIdTo"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
                    

                    return View(transferOut);
                }

                //check stock
                bool isStockOK = true;
                string productList = "";
                List<TransferOrderLine> stocklines = new List<TransferOrderLine>();
                stocklines = _context.TransferOrderLine
                    .Include(x => x.transferOrder)
                    .Include(x => x.product)
                    .Where(x => x.transferOrderId.Equals(transferOut.transferOrderId)).ToList();
                foreach (var item in stocklines)
                {
                    VMStock stock = _netcoreService.GetStockByProductAndWarehouse(item.productId, item.transferOrder.warehouseIdFrom);
                    if (stock != null)
                    {
                        if (stock.QtyOnhand < item.qty)
                        {
                            isStockOK = false;
                            productList = productList + " [" + item.product.productCode + "] ";
                        }
                    }
                    else
                    {
                        isStockOK = false;
                    }
                }

                if (!isStockOK)
                {
                    TempData["StatusMessage"] = "Error. Stock quantity problem, please check your on hand stock. " + productList;
                    return RedirectToAction(nameof(Create));
                }

                TransferOrder to = await _context.TransferOrder.Where(x => x.transferOrderId.Equals(transferOut.transferOrderId)).FirstOrDefaultAsync();
                transferOut.warehouseIdFrom = to.warehouseIdFrom;
                transferOut.warehouseIdTo = to.warehouseIdTo;


                transferOut.warehouseFrom = await _context.Warehouse.Include(x => x.branch).SingleOrDefaultAsync(x => x.warehouseId.Equals(transferOut.warehouseIdFrom));
                transferOut.branchFrom = transferOut.warehouseFrom.branch;
                transferOut.warehouseTo = await _context.Warehouse.Include(x => x.branch).SingleOrDefaultAsync(x => x.warehouseId.Equals(transferOut.warehouseIdTo));
                transferOut.branchTo = transferOut.warehouseTo.branch;

                to.isIssued = true;

                _context.Add(transferOut);
                await _context.SaveChangesAsync();


                //auto create transfer out line, full shipment
                List<TransferOrderLine> lines = new List<TransferOrderLine>();
                lines = _context.TransferOrderLine.Include(x => x.product).Where(x => x.transferOrderId.Equals(transferOut.transferOrderId)).ToList();
                foreach (var item in lines)
                {
                    TransferOutLine line = new TransferOutLine();
                    line.transferOut = transferOut;
                    line.product = item.product;
                    line.qty = item.qty;
                    line.qtyInventory = line.qty * -1;
                    

                    _context.TransferOutLine.Add(line);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Details), new { id = transferOut.transferOutId });
            }
            ViewData["transferOrderId"] = new SelectList(_context.TransferOrder, "transferOrderId", "transferOrderNumber", transferOut.transferOrderId);
            return View(transferOut);
        }

        // GET: TransferOut/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferOut = await _context.TransferOut
                .Include(x => x.branchFrom)
                .Include(x => x.branchTo)
                .Include(x => x.warehouseFrom)
                .Include(x => x.warehouseTo)
                .SingleOrDefaultAsync(m => m.transferOutId == id);
            if (transferOut == null)
            {
                return NotFound();
            }
            ViewData["transferOrderId"] = new SelectList(_context.TransferOrder, "transferOrderId", "transferOrderNumber", transferOut.transferOrderId);
            ViewData["branchIdFrom"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdFrom"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            ViewData["branchIdTo"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdTo"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            return View(transferOut);
        }

        // POST: TransferOut/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("transferOutId,transferOrderId,transferOutNumber,transferOutDate,description,branchIdFrom,warehouseIdFrom,branchIdTo,warehouseIdTo,HasChild,createdAt")] TransferOut transferOut)
        {
            if (id != transferOut.transferOutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transferOut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransferOutExists(transferOut.transferOutId))
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
            ViewData["transferOrderId"] = new SelectList(_context.TransferOrder, "transferOrderId", "transferOrderNumber", transferOut.transferOrderId);
            ViewData["branchIdFrom"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdFrom"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            ViewData["branchIdTo"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["warehouseIdTo"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            return View(transferOut);
        }

        // GET: TransferOut/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferOut = await _context.TransferOut
                    .Include(x => x.branchFrom)
                    .Include(x => x.branchTo)
                    .Include(x => x.warehouseFrom)
                    .Include(x => x.warehouseTo)
                    .Include(t => t.transferOrder)
                    .SingleOrDefaultAsync(m => m.transferOutId == id);
            if (transferOut == null)
            {
                return NotFound();
            }

            return View(transferOut);
        }




        // POST: TransferOut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transferOut = await _context.TransferOut
                .Include(x => x.transferOutLine)
                .Include(x => x.transferOrder)
                .SingleOrDefaultAsync(m => m.transferOutId == id);

            if (transferOut.transferOrder.isReceived == true)
            {
                ViewData["StatusMessage"] = "Error. Please delete Goods Receive first.";
                return View(transferOut);
            }

            try
            {
                _context.TransferOutLine.RemoveRange(transferOut.transferOutLine);
                _context.TransferOut.Remove(transferOut);
                transferOut.transferOrder.isIssued = false;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return View(transferOut);
            }
            
        }

        private bool TransferOutExists(string id)
        {
            return _context.TransferOut.Any(e => e.transferOutId == id);
        }

    }
}





namespace netcore.MVC
{
    public static partial class Pages
    {
        public static class TransferOut
        {
            public const string Controller = "TransferOut";
            public const string Action = "Index";
            public const string Role = "TransferOut";
            public const string Url = "/TransferOut/Index";
            public const string Name = "TransferOut";
        }
    }
}
namespace netcore.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "TransferOut")]
        public bool TransferOutRole { get; set; } = false;
    }
}



