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


    [Authorize(Roles = "TransferOutLine")]
    public class TransferOutLineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransferOutLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TransferOutLine
        public async Task<IActionResult> Index()
        {
                    var applicationDbContext = _context.TransferOutLine.Include(t => t.product).Include(t => t.transferOut);
                    return View(await applicationDbContext.ToListAsync());
        }        

    // GET: TransferOutLine/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var transferOutLine = await _context.TransferOutLine
                .Include(t => t.product)
                .Include(t => t.transferOut)
                    .SingleOrDefaultAsync(m => m.transferOutLineId == id);
        if (transferOutLine == null)
        {
            return NotFound();
        }

        return View(transferOutLine);
    }


    // GET: TransferOutLine/Create
    public IActionResult Create(string masterid, string id)
    {
        var check = _context.TransferOutLine.SingleOrDefault(m => m.transferOutLineId == id);
        var selected = _context.TransferOut.SingleOrDefault(m => m.transferOutId == masterid);
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productId");
            ViewData["transferOutId"] = new SelectList(_context.TransferOut, "transferOutId", "transferOutId");
        if (check == null)
        {
            TransferOutLine objline = new TransferOutLine();
            objline.transferOut = selected;
            objline.transferOutId = masterid;
            return View(objline);
        }
        else
        {
            return View(check);
        }
    }




    // POST: TransferOutLine/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("transferOutLineId,transferOutId,productId,qty,qtyInventory,createdAt")] TransferOutLine transferOutLine)
    {
        if (ModelState.IsValid)
        {
            _context.Add(transferOutLine);
            await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
                ViewData["productId"] = new SelectList(_context.Product, "productId", "productId", transferOutLine.productId);
                ViewData["transferOutId"] = new SelectList(_context.TransferOut, "transferOutId", "transferOutId", transferOutLine.transferOutId);
        return View(transferOutLine);
    }

    // GET: TransferOutLine/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var transferOutLine = await _context.TransferOutLine.SingleOrDefaultAsync(m => m.transferOutLineId == id);
        if (transferOutLine == null)
        {
            return NotFound();
        }
                ViewData["productId"] = new SelectList(_context.Product, "productId", "productId", transferOutLine.productId);
                ViewData["transferOutId"] = new SelectList(_context.TransferOut, "transferOutId", "transferOutId", transferOutLine.transferOutId);
        return View(transferOutLine);
    }

    // POST: TransferOutLine/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("transferOutLineId,transferOutId,productId,qty,qtyInventory,createdAt")] TransferOutLine transferOutLine)
    {
        if (id != transferOutLine.transferOutLineId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(transferOutLine);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransferOutLineExists(transferOutLine.transferOutLineId))
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
                ViewData["productId"] = new SelectList(_context.Product, "productId", "productId", transferOutLine.productId);
                ViewData["transferOutId"] = new SelectList(_context.TransferOut, "transferOutId", "transferOutId", transferOutLine.transferOutId);
        return View(transferOutLine);
    }

    // GET: TransferOutLine/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var transferOutLine = await _context.TransferOutLine
                .Include(t => t.product)
                .Include(t => t.transferOut)
                .SingleOrDefaultAsync(m => m.transferOutLineId == id);
        if (transferOutLine == null)
        {
            return NotFound();
        }

        return View(transferOutLine);
    }




    // POST: TransferOutLine/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var transferOutLine = await _context.TransferOutLine.SingleOrDefaultAsync(m => m.transferOutLineId == id);
            _context.TransferOutLine.Remove(transferOutLine);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TransferOutLineExists(string id)
    {
        return _context.TransferOutLine.Any(e => e.transferOutLineId == id);
    }

  }
}





namespace netcore.MVC
{
  public static partial class Pages
  {
      public static class TransferOutLine
      {
          public const string Controller = "TransferOutLine";
          public const string Action = "Index";
          public const string Role = "TransferOutLine";
          public const string Url = "/TransferOutLine/Index";
          public const string Name = "TransferOutLine";
      }
  }
}
namespace netcore.Models
{
  public partial class ApplicationUser
  {
      [Display(Name = "TransferOutLine")]
      public bool TransferOutLineRole { get; set; } = false;
  }
}



