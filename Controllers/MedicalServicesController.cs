using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tp_nt1.Database;
using tp_nt1.Models;

namespace tp_nt1a_1.Controllers
{
    [Authorize]
    public class MedicalServicesController : Controller
    {
        private readonly ScheduleDbContext _context;

        public MedicalServicesController(ScheduleDbContext context)
        {
            _context = context;
        }

        // GET: MedicalServices
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicalServices.ToListAsync());
        }

        // GET: MedicalServices/Details/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalService = await _context.MedicalServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalService == null)
            {
                return NotFound();
            }

            return View(medicalService);
        }

        // GET: MedicalServices/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(MedicalService medicalService)
        {
            if (ModelState.IsValid)
            {
                medicalService.Id = Guid.NewGuid();
                _context.Add(medicalService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalService);
        }

        // GET: MedicalServices/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalService = await _context.MedicalServices.FindAsync(id);
            if (medicalService == null)
            {
                return NotFound();
            }
            return View(medicalService);
        }

        // POST: MedicalServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(Guid id,  MedicalService medicalService)
        {
            if (id != medicalService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalServiceExists(medicalService.Id))
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
            return View(medicalService);
        }

        // GET: MedicalServices/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalService = await _context.MedicalServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalService == null)
            {
                return NotFound();
            }

            return View(medicalService);
        }

        // POST: MedicalServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var medicalService = await _context.MedicalServices.FindAsync(id);
            _context.MedicalServices.Remove(medicalService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalServiceExists(Guid id)
        {
            return _context.MedicalServices.Any(e => e.Id == id);
        }
    }
}
