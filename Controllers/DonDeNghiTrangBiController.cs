using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class DonDeNghiTrangBiController : Controller
    {
        private readonly QuanLyTrangBiCnttContext _context;

        public DonDeNghiTrangBiController(QuanLyTrangBiCnttContext context)
        {
            _context = context;
        }

        // GET: DonDeNghiTrangBi
        public async Task<IActionResult> Index()
        {
            var quanLyTrangBiCnttContext = _context.DonDeNghiTrangBis.Include(d => d.IdDenghiNavigation).Include(d => d.IdDonDeNghiNavigation).Include(d => d.IdTrangBiNavigation);
            return View(await quanLyTrangBiCnttContext.ToListAsync());
        }

        // GET: DonDeNghiTrangBi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DonDeNghiTrangBis == null)
            {
                return NotFound();
            }

            var donDeNghiTrangBi = await _context.DonDeNghiTrangBis
                .Include(d => d.IdDenghiNavigation)
                .Include(d => d.IdDonDeNghiNavigation)
                .Include(d => d.IdTrangBiNavigation)
                .FirstOrDefaultAsync(m => m.IdTrangBi == id);
            if (donDeNghiTrangBi == null)
            {
                return NotFound();
            }

            return View(donDeNghiTrangBi);
        }

        // GET: DonDeNghiTrangBi/Create
        public IActionResult Create()
        {
            ViewData["IdDenghi"] = new SelectList(_context.DeNghis, "IdDeNghi", "IdDeNghi");
            ViewData["IdDonDeNghi"] = new SelectList(_context.DonDeNghis, "IdDonDeNghi", "IdDonDeNghi");
            ViewData["IdTrangBi"] = new SelectList(_context.TrangBis, "IdTrangThietBi", "IdTrangThietBi");
            return View();
        }

        // POST: DonDeNghiTrangBi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTrangBi,IdDonDeNghi,IdDenghi")] DonDeNghiTrangBi donDeNghiTrangBi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donDeNghiTrangBi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDenghi"] = new SelectList(_context.DeNghis, "IdDeNghi", "IdDeNghi", donDeNghiTrangBi.IdDenghi);
            ViewData["IdDonDeNghi"] = new SelectList(_context.DonDeNghis, "IdDonDeNghi", "IdDonDeNghi", donDeNghiTrangBi.IdDonDeNghi);
            ViewData["IdTrangBi"] = new SelectList(_context.TrangBis, "IdTrangThietBi", "IdTrangThietBi", donDeNghiTrangBi.IdTrangBi);
            return View(donDeNghiTrangBi);
        }

        // GET: DonDeNghiTrangBi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DonDeNghiTrangBis == null)
            {
                return NotFound();
            }

            var donDeNghiTrangBi = await _context.DonDeNghiTrangBis.FindAsync(id);
            if (donDeNghiTrangBi == null)
            {
                return NotFound();
            }
            ViewData["IdDenghi"] = new SelectList(_context.DeNghis, "IdDeNghi", "IdDeNghi", donDeNghiTrangBi.IdDenghi);
            ViewData["IdDonDeNghi"] = new SelectList(_context.DonDeNghis, "IdDonDeNghi", "IdDonDeNghi", donDeNghiTrangBi.IdDonDeNghi);
            ViewData["IdTrangBi"] = new SelectList(_context.TrangBis, "IdTrangThietBi", "IdTrangThietBi", donDeNghiTrangBi.IdTrangBi);
            return View(donDeNghiTrangBi);
        }

        // POST: DonDeNghiTrangBi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTrangBi,IdDonDeNghi,IdDenghi")] DonDeNghiTrangBi donDeNghiTrangBi)
        {
            if (id != donDeNghiTrangBi.IdTrangBi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donDeNghiTrangBi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonDeNghiTrangBiExists(donDeNghiTrangBi.IdTrangBi))
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
            ViewData["IdDenghi"] = new SelectList(_context.DeNghis, "IdDeNghi", "IdDeNghi", donDeNghiTrangBi.IdDenghi);
            ViewData["IdDonDeNghi"] = new SelectList(_context.DonDeNghis, "IdDonDeNghi", "IdDonDeNghi", donDeNghiTrangBi.IdDonDeNghi);
            ViewData["IdTrangBi"] = new SelectList(_context.TrangBis, "IdTrangThietBi", "IdTrangThietBi", donDeNghiTrangBi.IdTrangBi);
            return View(donDeNghiTrangBi);
        }

        // GET: DonDeNghiTrangBi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DonDeNghiTrangBis == null)
            {
                return NotFound();
            }

            var donDeNghiTrangBi = await _context.DonDeNghiTrangBis
                .Include(d => d.IdDenghiNavigation)
                .Include(d => d.IdDonDeNghiNavigation)
                .Include(d => d.IdTrangBiNavigation)
                .FirstOrDefaultAsync(m => m.IdTrangBi == id);
            if (donDeNghiTrangBi == null)
            {
                return NotFound();
            }

            return View(donDeNghiTrangBi);
        }

        // POST: DonDeNghiTrangBi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DonDeNghiTrangBis == null)
            {
                return Problem("Entity set 'QuanLyTrangBiCnttContext.DonDeNghiTrangBis'  is null.");
            }
            var donDeNghiTrangBi = await _context.DonDeNghiTrangBis.FindAsync(id);
            if (donDeNghiTrangBi != null)
            {
                _context.DonDeNghiTrangBis.Remove(donDeNghiTrangBi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonDeNghiTrangBiExists(int id)
        {
          return (_context.DonDeNghiTrangBis?.Any(e => e.IdTrangBi == id)).GetValueOrDefault();
        }
    }
}
