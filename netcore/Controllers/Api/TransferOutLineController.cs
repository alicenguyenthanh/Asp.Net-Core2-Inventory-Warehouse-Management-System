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
    [Route("api/TransferOutLine")]
    public class TransferOutLineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransferOutLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TransferOutLine
        [HttpGet]
        [Authorize]
        public IActionResult GetTransferOutLine(string masterid)
        {
            return Json(new { data = _context.TransferOutLine.Include(x => x.product).Where(x => x.transferOutId.Equals(masterid)).ToList() });
        }

        // POST: api/TransferOutLine
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostTransferOutLine([FromBody] TransferOutLine transferOutLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (transferOutLine.transferOutLineId == string.Empty)
            {
                transferOutLine.transferOutLineId = Guid.NewGuid().ToString();
                _context.TransferOutLine.Add(transferOutLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(transferOutLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Edit data success." });
            }

        }

        // DELETE: api/TransferOutLine/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult>  DeleteTransferOutLine([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transferOutLine = await _context.TransferOutLine.SingleOrDefaultAsync(m => m.transferOutLineId == id);
            if (transferOutLine == null)
            {
                return NotFound();
            }

            _context.TransferOutLine.Remove(transferOutLine);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }


        private bool TransferOutLineExists(string id)
        {
            return _context.TransferOutLine.Any(e => e.transferOutLineId == id);
        }


    }

}
