using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sample6.Models;

namespace sample6.Controllers
{
    public class SampleTableController : Controller
    {
        private readonly PostgresContext _context;

        public SampleTableController(PostgresContext context)
        {
            _context = context;
        }

        // GET: SampleTable
        public async Task<IActionResult> Index()
        {
            return View(await _context.SampleTables.ToListAsync());
        }

        // GET: SampleTable/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleTable = await _context.SampleTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sampleTable == null)
            {
                return NotFound();
            }

            return View(sampleTable);
        }

        // GET: SampleTable/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SampleTable/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IntColumn1,IntColumn2,VarcharColumn1,VarcharColumn2,VarcharColumn3,CreatedColumn1,ModifyColumn2")] SampleTable sampleTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sampleTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sampleTable);
        }

        // GET: SampleTable/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleTable = await _context.SampleTables.FindAsync(id);
            if (sampleTable == null)
            {
                return NotFound();
            }
            return View(sampleTable);
        }

        // POST: SampleTable/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IntColumn1,IntColumn2,VarcharColumn1,VarcharColumn2,VarcharColumn3,CreatedColumn1,ModifyColumn2")] SampleTable sampleTable)
        {
            if (id != sampleTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sampleTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleTableExists(sampleTable.Id))
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
            return View(sampleTable);
        }

        // GET: SampleTable/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleTable = await _context.SampleTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sampleTable == null)
            {
                return NotFound();
            }

            return View(sampleTable);
        }

        // POST: SampleTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sampleTable = await _context.SampleTables.FindAsync(id);
            if (sampleTable != null)
            {
                _context.SampleTables.Remove(sampleTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SampleTableExists(int id)
        {
            return _context.SampleTables.Any(e => e.Id == id);
        }
    }
}
