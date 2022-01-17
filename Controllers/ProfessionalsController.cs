using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tp_nt1.Database;
using tp_nt1.Extensions;
using tp_nt1.Models;

namespace tp_nt1a_1.Controllers
{
    public class ProfessionalsController : Controller
    {
        private readonly ScheduleDbContext _context;

        public ProfessionalsController(ScheduleDbContext context)
        {
            _context = context;
        }

        // GET: Professionals
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            var scheduleDbContext = _context.Professionals.Include(p => p.MedicalService);
            return View(await scheduleDbContext.ToListAsync());
        }

        // GET: Professionals/Details/5
        [Authorize(Roles = "Administrador, Paciente")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professional = await _context.Professionals
                .Include(p => p.MedicalService)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professional == null)
            {
                return NotFound();
            }

            return View(professional);
        }

        // GET: Professionals/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            ViewData["MedicalServiceId"] = new SelectList(_context.MedicalServices, "Id", "Name");
            return View();
        }

        // POST: Professionals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(Professional professional, string pass)
        {
            try
            {
                pass.ValidatePassword();
            }
            catch (Exception e)
            {
                ModelState.AddModelError(nameof(Professional.Password), e.Message);
            }

            if (_context.Admins.Any(prof => prof.Email == professional.Email))
            {
                ModelState.AddModelError(nameof(Professional.Email), "El email ya se encuentra utilizado");
            }

            if (ModelState.IsValid)
            {
                professional.Id = Guid.NewGuid();
                professional.CreationDate = DateTime.Now;
                professional.Password = pass.Encrypt();
                _context.Add(professional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicalServiceId"] = new SelectList(_context.MedicalServices, "Id", "Name", professional.MedicalServiceId);
            return View(professional);
        }

        // GET: Professionals/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professional = await _context.Professionals.FindAsync(id);
            if (professional == null)
            {
                return NotFound();
            }
            ViewData["MedicalServiceId"] = new SelectList(_context.MedicalServices, "Id", "Description", professional.MedicalServiceId);
            return View(professional);
        }

        // POST: Professionals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(Guid id, Professional professional)
        {
            if (id != professional.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalExists(professional.Id))
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
            ViewData["MedicalServiceId"] = new SelectList(_context.MedicalServices, "Id", "Description", professional.MedicalServiceId);
            return View(professional);
        }

        // GET: Professionals/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professional = await _context.Professionals
                .Include(p => p.MedicalService)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professional == null)
            {
                return NotFound();
            }

            return View(professional);
        }

        // POST: Professionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var professional = await _context.Professionals.FindAsync(id);
            _context.Professionals.Remove(professional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionalExists(Guid id)
        {
            return _context.Professionals.Any(e => e.Id == id);
        }

        
    }
}
