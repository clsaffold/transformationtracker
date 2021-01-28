using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransformationTracker.Data;
using TransformationTracker.Models;

namespace TransformationTracker.Controllers
{
    public class PdsasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PdsasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pdsas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pdsa.ToListAsync());
        }

        // GET: Pdsas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdsa = await _context.Pdsa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pdsa == null)
            {
                return NotFound();
            }

            return View(pdsa);
        }

        // GET: Pdsas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pdsas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Name,Shared,TacticId,Gap,Plan,Doing,Study")] Pdsa pdsa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pdsa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pdsa);
        }

        // GET: Pdsas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdsa = await _context.Pdsa.FindAsync(id);
            if (pdsa == null)
            {
                return NotFound();
            }
            return View(pdsa);
        }

        // POST: Pdsas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Name,Shared,TacticId,Gap,Plan,Doing,Study")] Pdsa pdsa)
        {
            if (id != pdsa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pdsa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PdsaExists(pdsa.Id))
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
            return View(pdsa);
        }

        // GET: Pdsas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdsa = await _context.Pdsa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pdsa == null)
            {
                return NotFound();
            }

            return View(pdsa);
        }

        // POST: Pdsas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pdsa = await _context.Pdsa.FindAsync(id);
            _context.Pdsa.Remove(pdsa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PdsaExists(int id)
        {
            return _context.Pdsa.Any(e => e.Id == id);
        }
    }
}
