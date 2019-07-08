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
    [Route("api/VendorLine")]
    public class VendorLineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendorLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/VendorLine
        [HttpGet]
        [Authorize]
        public IActionResult GetVendorLine(string masterid)
        {
            return Json(new { data = _context.VendorLine.Where(x => x.vendorId.Equals(masterid)).ToList() });
        }

        // POST: api/VendorLine
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostVendorLine([FromBody] VendorLine vendorLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (vendorLine.vendorLineId == string.Empty)
            {
                vendorLine.vendorLineId = Guid.NewGuid().ToString();
                _context.VendorLine.Add(vendorLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(vendorLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Edit data success." });
            }

        }

        // DELETE: api/VendorLine/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult>  DeleteVendorLine([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendorLine = await _context.VendorLine.SingleOrDefaultAsync(m => m.vendorLineId == id);
            if (vendorLine == null)
            {
                return NotFound();
            }

            _context.VendorLine.Remove(vendorLine);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }


        private bool VendorLineExists(string id)
        {
            return _context.VendorLine.Any(e => e.vendorLineId == id);
        }


    }

}
