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


    [Authorize(Roles = "Vendor")]
    public class VendorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vendor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vendor.OrderByDescending(x => x.createdAt).ToListAsync());
        }

        // GET: Vendor/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendor
                        .SingleOrDefaultAsync(m => m.vendorId == id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }


        // GET: Vendor/Create
        public IActionResult Create()
        {
            return View();
        }




        // POST: Vendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("vendorId,vendorName,description,size,street1,street2,city,province,country,HasChild,createdAt")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = vendor.vendorId });
            }
            return View(vendor);
        }

        // GET: Vendor/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendor.SingleOrDefaultAsync(m => m.vendorId == id);
            if (vendor == null)
            {
                return NotFound();
            }
            return View(vendor);
        }

        // POST: Vendor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("vendorId,vendorName,description,size,street1,street2,city,province,country,HasChild,createdAt")] Vendor vendor)
        {
            if (id != vendor.vendorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorExists(vendor.vendorId))
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
            return View(vendor);
        }

        // GET: Vendor/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendor
                    .SingleOrDefaultAsync(m => m.vendorId == id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }




        // POST: Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vendor = await _context.Vendor.Include(x => x.vendorLine).SingleOrDefaultAsync(m => m.vendorId == id);
            try
            {
                _context.VendorLine.RemoveRange(vendor.vendorLine);
                _context.Vendor.Remove(vendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return View(vendor);
            }
            
        }

        private bool VendorExists(string id)
        {
            return _context.Vendor.Any(e => e.vendorId == id);
        }

    }
}





namespace netcore.MVC
{
    public static partial class Pages
    {
        public static class Vendor
        {
            public const string Controller = "Vendor";
            public const string Action = "Index";
            public const string Role = "Vendor";
            public const string Url = "/Vendor/Index";
            public const string Name = "Vendor";
        }
    }
}
namespace netcore.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Vendor")]
        public bool VendorRole { get; set; } = false;
    }
}



