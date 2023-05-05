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
    public class PlaylistsModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaylistsModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlaylistsModels
        public async Task<IActionResult> Index()
        {
              return _context.PlaylistsModel != null ? 
                          View(await _context.PlaylistsModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PlaylistsModel'  is null.");
        }

        // GET: PlaylistsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlaylistsModel == null)
            {
                return NotFound();
            }

            var playlistsModel = await _context.PlaylistsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlistsModel == null)
            {
                return NotFound();
            }

            return View(playlistsModel);
        }

        // GET: PlaylistsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlaylistsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Title,Description")] PlaylistsModel playlistsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlistsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlistsModel);
        }

        // GET: PlaylistsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlaylistsModel == null)
            {
                return NotFound();
            }

            var playlistsModel = await _context.PlaylistsModel.FindAsync(id);
            if (playlistsModel == null)
            {
                return NotFound();
            }
            return View(playlistsModel);
        }

        // POST: PlaylistsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Title,Description")] PlaylistsModel playlistsModel)
        {
            if (id != playlistsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlistsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistsModelExists(playlistsModel.Id))
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
            return View(playlistsModel);
        }

        // GET: PlaylistsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlaylistsModel == null)
            {
                return NotFound();
            }

            var playlistsModel = await _context.PlaylistsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlistsModel == null)
            {
                return NotFound();
            }

            return View(playlistsModel);
        }

        // POST: PlaylistsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlaylistsModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PlaylistsModel'  is null.");
            }
            var playlistsModel = await _context.PlaylistsModel.FindAsync(id);
            if (playlistsModel != null)
            {
                _context.PlaylistsModel.Remove(playlistsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistsModelExists(int id)
        {
          return (_context.PlaylistsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
