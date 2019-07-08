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


    [Authorize(Roles = "VendorLine")]
    public class VendorLineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendorLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VendorLine
        public async Task<IActionResult> Index()
        {
                    var applicationDbContext = _context.VendorLine.Include(v => v.vendor);
                    return View(await applicationDbContext.ToListAsync());
        }        

    // GET: VendorLine/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vendorLine = await _context.VendorLine
                .Include(v => v.vendor)
                    .SingleOrDefaultAsync(m => m.vendorLineId == id);
        if (vendorLine == null)
        {
            return NotFound();
        }

        return View(vendorLine);
    }


    // GET: VendorLine/Create
    public IActionResult Create(string masterid, string id)
    {
        var check = _context.VendorLine.SingleOrDefault(m => m.vendorLineId == id);
        var selected = _context.Vendor.SingleOrDefault(m => m.vendorId == masterid);
            ViewData["vendorId"] = new SelectList(_context.Vendor, "vendorId", "vendorId");
        if (check == null)
        {
            VendorLine objline = new VendorLine();
            objline.vendor = selected;
            objline.vendorId = masterid;
            return View(objline);
        }
        else
        {
            return View(check);
        }
    }




    // POST: VendorLine/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("vendorLineId,jobTitle,vendorId,firstName,lastName,middleName,nickName,gender,salutation,mobilePhone,officePhone,fax,personalEmail,workEmail,createdAt")] VendorLine vendorLine)
    {
        if (ModelState.IsValid)
        {
            _context.Add(vendorLine);
            await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
                ViewData["vendorId"] = new SelectList(_context.Vendor, "vendorId", "vendorId", vendorLine.vendorId);
        return View(vendorLine);
    }

    // GET: VendorLine/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vendorLine = await _context.VendorLine.SingleOrDefaultAsync(m => m.vendorLineId == id);
        if (vendorLine == null)
        {
            return NotFound();
        }
                ViewData["vendorId"] = new SelectList(_context.Vendor, "vendorId", "vendorId", vendorLine.vendorId);
        return View(vendorLine);
    }

    // POST: VendorLine/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("vendorLineId,jobTitle,vendorId,firstName,lastName,middleName,nickName,gender,salutation,mobilePhone,officePhone,fax,personalEmail,workEmail,createdAt")] VendorLine vendorLine)
    {
        if (id != vendorLine.vendorLineId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(vendorLine);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorLineExists(vendorLine.vendorLineId))
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
                ViewData["vendorId"] = new SelectList(_context.Vendor, "vendorId", "vendorId", vendorLine.vendorId);
        return View(vendorLine);
    }

    // GET: VendorLine/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vendorLine = await _context.VendorLine
                .Include(v => v.vendor)
                .SingleOrDefaultAsync(m => m.vendorLineId == id);
        if (vendorLine == null)
        {
            return NotFound();
        }

        return View(vendorLine);
    }




    // POST: VendorLine/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var vendorLine = await _context.VendorLine.SingleOrDefaultAsync(m => m.vendorLineId == id);
            _context.VendorLine.Remove(vendorLine);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool VendorLineExists(string id)
    {
        return _context.VendorLine.Any(e => e.vendorLineId == id);
    }

  }
}





namespace netcore.MVC
{
  public static partial class Pages
  {
      public static class VendorLine
      {
          public const string Controller = "VendorLine";
          public const string Action = "Index";
          public const string Role = "VendorLine";
          public const string Url = "/VendorLine/Index";
          public const string Name = "VendorLine";
      }
  }
}
namespace netcore.Models
{
  public partial class ApplicationUser
  {
      [Display(Name = "VendorLine")]
      public bool VendorLineRole { get; set; } = false;
  }
}



