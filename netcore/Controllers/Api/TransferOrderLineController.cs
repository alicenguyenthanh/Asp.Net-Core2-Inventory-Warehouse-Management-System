using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using netcore.Data;
using netcore.Models.Invent;

namespace netcore.Controllers.Api
{

    [Produces("application/json")]
    [Route("api/TransferOrderLine")]
    public class TransferOrderLineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransferOrderLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TransferOrderLine
        [HttpGet]
        [Authorize]
        public IActionResult GetTransferOrderLine(string masterid)
        {
            return Json(new { data = _context.TransferOrderLine.Include(x => x.product).Where(x => x.transferOrderId.Equals(masterid)).ToList() });
        }

        // POST: api/TransferOrderLine
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostTransferOrderLine([FromBody] TransferOrderLine transferOrderLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TransferOrder transferOrder = await _context.TransferOrder.Where(x => x.transferOrderId.Equals(transferOrderLine.transferOrderId)).FirstOrDefaultAsync();

            if (transferOrder.transferOrderStatus == TransferOrderStatus.Completed)
            {
                return Json(new { success = false, message = "Lỗi. Không thẻ sửa [Completed]." });
            }

            if (transferOrder.isIssued == true)
            {
                return Json(new { success = false, message = "Lỗi. Không thể chỉnh sửa đơn hàng [Mở] đã xử lý sự cố hàng hóa" });
            }

            if (transferOrder.isReceived == true)
            {
                return Json(new { success = false, message = "Lỗi. Không thể chỉnh sửa đơn hàng [Mở] đã xử lý hàng hóa nhận được" });
            }

            if (transferOrderLine.transferOrderLineId == string.Empty)
            {
                transferOrderLine.transferOrderLineId = Guid.NewGuid().ToString();
                _context.TransferOrderLine.Add(transferOrderLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(transferOrderLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Edit data success." });
            }

        }

        // DELETE: api/TransferOrderLine/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult>  DeleteTransferOrderLine([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transferOrderLine = await _context.TransferOrderLine
                .Include(x => x.transferOrder)
                .SingleOrDefaultAsync(m => m.transferOrderLineId == id);
            if (transferOrderLine == null)
            {
                return NotFound();
            }

            if (transferOrderLine.transferOrder.transferOrderStatus == TransferOrderStatus.Completed
                || transferOrderLine.transferOrder.isIssued == true
                || transferOrderLine.transferOrder.isReceived == true)
            {
                return Json(new { success = false, message = "Lỗi. Không thể xóa đơn hàng [Completed] hoặc [Open] đã xử lý vấn đề hàng hóa hoặc hàng hóa nhận được" });
            }

            _context.TransferOrderLine.Remove(transferOrderLine);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Xóa thành công." });
        }


        private bool TransferOrderLineExists(string id)
        {
            return _context.TransferOrderLine.Any(e => e.transferOrderLineId == id);
        }


    }

}
