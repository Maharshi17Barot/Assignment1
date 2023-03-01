using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1.Data;
using Assignment1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment1.Controllers
{
    public class itemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public itemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: item
        public async Task<IActionResult> Index()
        {
              return _context.Item != null ? 
                          View(await _context.Item.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Item'  is null.");
        }

       
        public async Task<IActionResult> SearchForm()
        {
            return _context.Item != null ?
                        View() :
                        Problem("Entity set 'ApplicationDbContext.Item'  is null.");
        }

        public async Task<IActionResult> SearchResult(String SearchPhrase)
        {
            return View("Index", await _context.Item.Where(j => j.itemName.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: item/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,itemName,itemCost,itemDetails,startDate,endDate,category,condition,picture")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: item/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

			return View(item);
        }

        // POST: item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,itemName,itemCost,itemDetails,startDate,endDate,category,condition,picture")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            return View(item);
        }

        // GET: item/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: item/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Item == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Item'  is null.");
            }
            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Item.Remove(item);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
          return (_context.Item?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
