using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spot_test.Data;
using Spot_test.Models;

namespace Spot_test.Controllers
{
    public class PlaylistsModel2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaylistsModel2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlaylistsModel2
        public async Task<IActionResult> Index()
        {
              return _context.PlaylistsModel2 != null ? 
                          View(await _context.PlaylistsModel2.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PlaylistsModel2'  is null.");
        }

        // GET: PlaylistsModel2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlaylistsModel2 == null)
            {
                return NotFound();
            }

            var playlistsModel2 = await _context.PlaylistsModel2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlistsModel2 == null)
            {
                return NotFound();
            }

            return View(playlistsModel2);
        }

        // GET: PlaylistsModel2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlaylistsModel2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Title,Description,Pinned")] PlaylistsModel2 playlistsModel2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlistsModel2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlistsModel2);
        }

        // GET: PlaylistsModel2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlaylistsModel2 == null)
            {
                return NotFound();
            }

            var playlistsModel2 = await _context.PlaylistsModel2.FindAsync(id);
            if (playlistsModel2 == null)
            {
                return NotFound();
            }
            return View(playlistsModel2);
        }

        // POST: PlaylistsModel2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Title,Description,Pinned")] PlaylistsModel2 playlistsModel2)
        {
            if (id != playlistsModel2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlistsModel2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistsModel2Exists(playlistsModel2.Id))
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
            return View(playlistsModel2);
        }

        // GET: PlaylistsModel2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlaylistsModel2 == null)
            {
                return NotFound();
            }

            var playlistsModel2 = await _context.PlaylistsModel2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlistsModel2 == null)
            {
                return NotFound();
            }

            return View(playlistsModel2);
        }

        // POST: PlaylistsModel2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlaylistsModel2 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PlaylistsModel2'  is null.");
            }
            var playlistsModel2 = await _context.PlaylistsModel2.FindAsync(id);
            if (playlistsModel2 != null)
            {
                _context.PlaylistsModel2.Remove(playlistsModel2);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistsModel2Exists(int id)
        {
          return (_context.PlaylistsModel2?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
