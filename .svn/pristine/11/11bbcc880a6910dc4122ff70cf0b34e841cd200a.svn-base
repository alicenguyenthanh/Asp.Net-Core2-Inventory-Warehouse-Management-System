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


    [Authorize(Roles = "Shipment")]
    public class ShipmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INetcoreService _netcoreService;

        public ShipmentController(ApplicationDbContext context, INetcoreService netcoreService)
        {
            _context = context;
            _netcoreService = netcoreService;
        }

       
        public IActionResult GetWarehouseByOrder(string salesOrderId)
        {
            SalesOrder so = _context.SalesOrder
                .Include(x => x.branch)
                .Where(x => x.salesOrderId.Equals(salesOrderId)).FirstOrDefault();

            List<Warehouse> warehouseList = _context.Warehouse.Where(x => x.branchId.Equals(so.branch.branchId)).ToList();
            warehouseList.Insert(0, new Warehouse { warehouseId = "0", warehouseName = "Select" });

            return Json(new SelectList(warehouseList, "warehouseId", "warehouseName"));
        }

        public async Task<IActionResult> ShowDeliveryOrder(string id)
        {
            Shipment obj = await _context.Shipment
                .Include(x => x.customer)
                .Include(x => x.salesOrder)
                    .ThenInclude(x => x.branch)
                .Include(x => x.shipmentLine).ThenInclude(x => x.product)
                .SingleOrDefaultAsync(x => x.shipmentId.Equals(id));
            return View(obj);
        }

        public async Task<IActionResult> PrintDeliveryOrder(string id)
        {
            Shipment obj = await _context.Shipment
                .Include(x => x.customer)
                .Include(x => x.salesOrder)
                    .ThenInclude(x => x.branch)
                .Include(x => x.shipmentLine).ThenInclude(x => x.product)
                .SingleOrDefaultAsync(x => x.shipmentId.Equals(id));
            return View(obj);
        }

        // GET: Shipment
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Shipment.OrderByDescending(x => x.createdAt).Include(s => s.branch).Include(s => s.customer).Include(s => s.salesOrder).Include(s => s.warehouse);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Shipment/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment
                    .Include(s => s.branch)
                    .Include(s => s.customer)
                    .Include(s => s.salesOrder)
                    .Include(s => s.warehouse)
                        .SingleOrDefaultAsync(m => m.shipmentId == id);
            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }


        // GET: Shipment/Create
        public IActionResult Create()
        {
            ViewData["StatusMessage"] = TempData["StatusMessage"];
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName");
            ViewData["customerId"] = new SelectList(_context.Customer, "customerId", "customerName");
            List<SalesOrder> soList = _context.SalesOrder.Where(x => x.salesOrderStatus == SalesOrderStatus.Open).ToList();
            soList.Insert(0, new SalesOrder { salesOrderId = "0", salesOrderNumber = "Select" });
            ViewData["salesOrderId"] = new SelectList(soList, "salesOrderId", "salesOrderNumber");
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");
            Shipment shipment = new Shipment();
            return View(shipment);
        }




        // POST: Shipment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("shipmentId,salesOrderId,shipmentNumber,shipmentDate,customerId,customerPO,invoice,branchId,warehouseId,expeditionType,expeditionMode,HasChild,createdAt")] Shipment shipment)
        {
            if (shipment.salesOrderId == "0" || shipment.warehouseId == "0")
            {
                TempData["StatusMessage"] = "Error. Sales order or warehouse is not valid. Please select valid sales order and warehouse";
                return RedirectToAction(nameof(Create));
            }

            if (ModelState.IsValid)
            {
                //check sales order
                Shipment check = await _context.Shipment
                    .Include(x => x.salesOrder)
                    .SingleOrDefaultAsync(x => x.salesOrderId.Equals(shipment.salesOrderId));
                if (check != null)
                {
                    ViewData["StatusMessage"] = "Error. Sales order already shipped. " + check.shipmentNumber;

                    ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName");
                    ViewData["customerId"] = new SelectList(_context.Customer, "customerId", "customerName");
                    ViewData["salesOrderId"] = new SelectList(_context.SalesOrder, "salesOrderId", "salesOrderNumber");
                    ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName");

                    return View(shipment);
                }

                //check stock
                bool isStockOK = true;
                string productList = "";
                List<SalesOrderLine> stocklines = new List<SalesOrderLine>();
                stocklines = _context.SalesOrderLine
                    .Include(x => x.product)
                    .Where(x => x.salesOrderId.Equals(shipment.salesOrderId)).ToList();
                foreach (var item in stocklines)
                {
                    VMStock stock = _netcoreService.GetStockByProductAndWarehouse(item.productId, shipment.warehouseId);
                    if (stock != null)
                    {
                        if (stock.QtyOnhand < item.qty)
                        {
                            isStockOK = false;
                            productList = productList + " ["+item.product.productCode+"] ";
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

                shipment.warehouse = await _context.Warehouse.Include(x => x.branch).SingleOrDefaultAsync(x => x.warehouseId.Equals(shipment.warehouseId));
                shipment.branch = shipment.warehouse.branch;
                shipment.salesOrder = await _context.SalesOrder.Include(x => x.customer).SingleOrDefaultAsync(x => x.salesOrderId.Equals(shipment.salesOrderId));
                shipment.customer = shipment.salesOrder.customer;

                //change status of salesorder
                shipment.salesOrder.salesOrderStatus = SalesOrderStatus.Completed;
                _context.Update(shipment.salesOrder);

                _context.Add(shipment);
                await _context.SaveChangesAsync();

                //auto create shipment line, full shipment
                List<SalesOrderLine> solines = new List<SalesOrderLine>();
                solines = _context.SalesOrderLine.Include(x => x.product).Where(x => x.salesOrderId.Equals(shipment.salesOrderId)).ToList();
                foreach (var item in solines)
                {
                    ShipmentLine line = new ShipmentLine();
                    line.shipment = shipment;
                    line.product = item.product;
                    line.qty = item.qty;
                    line.qtyShipment = item.qty;
                    line.qtyInventory = line.qtyShipment * -1;
                    line.branchId = shipment.branchId;
                    line.warehouseId = shipment.warehouseId;

                    _context.ShipmentLine.Add(line);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Details), new { id = shipment.shipmentId });
            }
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName", shipment.branchId);
            ViewData["customerId"] = new SelectList(_context.Customer, "customerId", "customerName", shipment.customerId);
            ViewData["salesOrderId"] = new SelectList(_context.SalesOrder, "salesOrderId", "salesOrderNumber", shipment.salesOrderId);
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName", shipment.warehouseId);
            return View(shipment);
        }

        // GET: Shipment/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment.SingleOrDefaultAsync(m => m.shipmentId == id);
            if (shipment == null)
            {
                return NotFound();
            }
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName", shipment.branchId);
            ViewData["customerId"] = new SelectList(_context.Customer, "customerId", "customerName", shipment.customerId);
            ViewData["salesOrderId"] = new SelectList(_context.SalesOrder, "salesOrderId", "salesOrderNumber", shipment.salesOrderId);
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName", shipment.warehouseId);
            return View(shipment);
        }

        // POST: Shipment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("shipmentId,salesOrderId,shipmentNumber,shipmentDate,customerId,customerPO,invoice,branchId,warehouseId,expeditionType,expeditionMode,HasChild,createdAt")] Shipment shipment)
        {
            if (id != shipment.shipmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipmentExists(shipment.shipmentId))
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
            ViewData["branchId"] = new SelectList(_context.Branch, "branchId", "branchName", shipment.branchId);
            ViewData["customerId"] = new SelectList(_context.Customer, "customerId", "customerName", shipment.customerId);
            ViewData["salesOrderId"] = new SelectList(_context.SalesOrder, "salesOrderId", "salesOrderNumber", shipment.salesOrderId);
            ViewData["warehouseId"] = new SelectList(_context.Warehouse, "warehouseId", "warehouseName", shipment.warehouseId);
            return View(shipment);
        }

        // GET: Shipment/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment
                    .Include(s => s.branch)
                    .Include(s => s.customer)
                    .Include(s => s.salesOrder)
                    .Include(s => s.warehouse)
                    .SingleOrDefaultAsync(m => m.shipmentId == id);
            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }




        // POST: Shipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var shipment = await _context.Shipment
                .Include(x => x.salesOrder)
                .Include(x => x.shipmentLine)
                .SingleOrDefaultAsync(m => m.shipmentId == id);
            try
            {
                _context.ShipmentLine.RemoveRange(shipment.shipmentLine);
                _context.Shipment.Remove(shipment);

                //rollback status to open
                shipment.salesOrder.salesOrderStatus = SalesOrderStatus.Open;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return View(shipment);
            }
            
        }

        private bool ShipmentExists(string id)
        {
            return _context.Shipment.Any(e => e.shipmentId == id);
        }

    }
}





namespace netcore.MVC
{
    public static partial class Pages
    {
        public static class Shipment
        {
            public const string Controller = "Shipment";
            public const string Action = "Index";
            public const string Role = "Shipment";
            public const string Url = "/Shipment/Index";
            public const string Name = "Shipment";
        }
    }
}
namespace netcore.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Shipment")]
        public bool ShipmentRole { get; set; } = false;
    }
}



