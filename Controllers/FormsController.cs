using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tp_nt1.Database;
using tp_nt1.Models;
using Microsoft.AspNetCore.Authorization;

namespace tp_nt1a_1.Controllers
{
    public class FormsController : Controller
    {
        private readonly ScheduleDbContext _context;

        public FormsController(ScheduleDbContext context)
        {
            _context = context;
        }

        // GET: Forms
        [Authorize(Roles = "Administrador, Profesional")]
        public async Task<IActionResult> Index()
        {
            var scheduleDbContext = _context.Forms.Include(f => f.Patient);
            return View(await scheduleDbContext.ToListAsync());
        }

        // GET: Forms/Details/5
        [Authorize(Roles = "Administrador, Profesional")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms
                .Include(f => f.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // GET: Forms/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            var model = new Form();
            if (User.IsInRole(nameof(Role.Paciente)))
            {
                var patientId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var patient = _context.Patients.Find(patientId);
                model.Email = patient.Email;
                model.FirstName = patient.FirstName;
                model.LastName = patient.LastName;
                model.PatientId = patientId;
            }

            return View(model);
        }

        // POST: Forms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create(Form form)
        {
            if (ModelState.IsValid)
            {
                form.Id = Guid.NewGuid();
                form.Read = false;

                if (User.IsInRole(nameof(Role.Paciente)))
                {
                    var patientId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    var patient = _context.Patients.Find(patientId);
                    form.PatientId = patientId;
                    form.Email = patient.Email;
                    form.FirstName = patient.FirstName;
                    form.LastName = patient.LastName;
                }
                form.Date = DateTime.Now;

                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            
            return View(form);
        }

        [HttpPost]
        [Authorize(Roles = "Profesional,Administrador")]
        public async Task<IActionResult> ChangeReadStatus(Guid formId)
        {
            var form = this._context.Forms.FirstOrDefault(f => f.Id == formId);

            form.Read = !form.Read;
            await this._context.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index));
        }


        

        // GET: Forms/Delete/5
        [Authorize(Roles = "Administrador, Profesional")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms
                .Include(f => f.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // POST: Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador, Profesional")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var form = await _context.Forms.FindAsync(id);
            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormExists(Guid id)
        {
            return _context.Forms.Any(e => e.Id == id);
        }
    }
}
