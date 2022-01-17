using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class TurnsController : Controller
    {
        private readonly ScheduleDbContext _context;

        public TurnsController(ScheduleDbContext context)
        {
            _context = context;
        }

        // GET: Turns
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            var scheduleDbContext = _context.Turns.Include(t => t.Patient).Include(t => t.Professional);

            foreach (var i in scheduleDbContext)
            {

                if (i.Date < DateTime.Now)
                {
                    i.Active = false;
                    await _context.SaveChangesAsync();

                }
            }
                return View(await scheduleDbContext.ToListAsync());
        }

        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> MyTurns()
        {
            var patientId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var turns = _context.Turns.Include(t => t.Professional).Where(t => t.Patient.Id == patientId);

            foreach (var i in turns){
              
                if (i.Date < DateTime.Now)
                {
                    i.Active = false;
                    await _context.SaveChangesAsync();

                }
            }
            return View(await turns.ToListAsync());
        }

        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> MyTurnsCantCreate()
        {
            var patientId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var turns = _context.Turns.Include(t => t.Professional).Where(t => t.Patient.Id == patientId);
            return View(await turns.ToListAsync());
        }

        [Authorize(Roles  = "Profesional")]
        public async Task<IActionResult> ProfessionalTurns()
        {
            var professionalId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var turns = _context.Turns.Include(t => t.Patient).Where(t => t.Professional.Id == professionalId && t.Date > DateTime.Now);
            return View(await turns.ToListAsync());
        }


        [HttpGet]
        [Authorize (Roles = "Profesional")]
        public async Task<IActionResult> Balance()
        {
            var professionalId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var turns = _context.Turns.Include(t => t.Patient)
                                      .Include(t => t.Professional)
                                      .ThenInclude(t => t.MedicalService)
                                      .Where(t => t.Professional.Id == professionalId && t.Date.Month == DateTime.Now.Month && t.Confirmed == true);

            List<Turn> turnsTotal = turns.ToList();

            var totalPrice = turnsTotal.Sum(t => t.Professional.MedicalService.Price);
            ViewData["Price"] = totalPrice;

            return View(await turns.ToListAsync());
        }

        [HttpPost]
        [Authorize(Roles = "Profesional,Administrador")]
        public async Task<IActionResult> ChangeConfirmedStatus(Guid turnId)
        {
            var turn = this._context.Turns.FirstOrDefault(t => t.Id == turnId);

            turn.Confirmed = !turn.Confirmed;
            await this._context.SaveChangesAsync();

            if (User.IsInRole(nameof(Role.Profesional)))
            {
                return this.RedirectToAction(nameof(ProfessionalTurns));
            } 
                return this.RedirectToAction(nameof(Index));
                           
        }


        // GET: Turns/Details/5
        [Authorize(Roles = "Administrador, Profesional, Paciente")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turn = await _context.Turns
                .Include(t => t.Patient)
                .Include(t => t.Professional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turn == null)
            {
                return NotFound();
            }

            return View(turn);
        }


        [Authorize(Roles = "Paciente")]
        public IActionResult SelectMedicalService()
        {
            var patientId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var turnsPatient = _context.Turns.Where(t => t.Patient.Id == patientId && t.Active == true);
            if (turnsPatient.Count() != 0)
            {
                ModelState.AddModelError(nameof(Patient.Turns), "Ya tiene un turno activo asignado.");
                return RedirectToAction(nameof(MyTurnsCantCreate));
            }

            else
            {
                ViewData["MedicalServiceId"] = new SelectList(_context.MedicalServices, "Id", "Name");
            }

            return View();
        }


        [Authorize(Roles = "Paciente")]
        public IActionResult SelectProffesional(Guid medicalServiceId)
        {

            TempData["medicalServiceId"] = medicalServiceId;
            ViewData["professionalId"] = new SelectList(_context.Professionals.Where(p => p.MedicalServiceId==medicalServiceId), "Id", nameof(Professional.FullName));
            return View();

        }


        // GET: Turns/Create
        [Authorize(Roles = "Paciente")]
        public IActionResult SelectDate(Guid professionalId, Guid medicalServiceId)
        {
            TempData["medicalServiceId"] = medicalServiceId;
            TempData["professionalId"] = professionalId;

            var medicalService = _context.MedicalServices.FirstOrDefault(medicalService => medicalService.Id == medicalServiceId);
            var medicalServiceName = medicalService.Name;
            ViewBag.medicalServiceName = medicalServiceName;

            var professional = _context.Professionals.FirstOrDefault(professional => professional.Id == professionalId);
            var professionalName = professional.FullName;
            ViewBag.professionalName = professionalName;

            var startTimeProfessional = professional.StartTime;
            var endTimeProfessional = professional.EndTime;
            var durationTurn = professional.MedicalService.Duration;
            var today = DateTime.Today.AddDays(1);
            var todayMoreSeven = today.AddDays(7);
            List<SelectList> listItems = new List<SelectList>();
            
            for (DateTime i = today; i < todayMoreSeven; i.AddDays(1))
                {
                    for (DateTime o = startTimeProfessional; o < endTimeProfessional; o.AddMinutes(durationTurn))
                    {
                     var diaStr = i.ToString("dd/MM/yyyy") + " " + o.ToString("HH:mm");

                    o = o.AddMinutes(durationTurn);
                    if (o < endTimeProfessional)
                    {

                        listItems.Add(new SelectList(listItems, diaStr, diaStr));
                        
                    }
                    
                }
                
                i = i.AddDays(1);
                startTimeProfessional = professional.StartTime;

                }

            var turnsProfessional = _context.Turns.Where(t => t.Professional.Id == professionalId && t.Active == true);

            foreach (var t in turnsProfessional)
            {
                var actulTurn = t.Date;
                var turnStr = actulTurn.ToString("dd/MM/yyyy HH:mm");
                    
                foreach (var i in listItems.ToList())
                {
                    var listTurn = i.DataTextField;
                    if (turnStr == listTurn)
                    {
                        listItems.Remove(i);
                          
                    }
                }
            }

            ViewData["date"] = new SelectList(listItems, "DataValueField" , "DataTextField");
             
            return View();
        }

        [Authorize(Roles = "Paciente")]
        public IActionResult ConfirmTurn(Guid professionalId, Guid medicalServiceId, String date)
        {
            TempData["medicalServiceId"] = medicalServiceId;
            TempData["professionalId"] = professionalId;
            TempData["date"] = date;

            var medicalService = _context.MedicalServices.FirstOrDefault(medicalService => medicalService.Id == medicalServiceId);
            var medicalServiceName = medicalService.Name;
            ViewBag.medicalServiceName = medicalServiceName;

            var professional = _context.Professionals.FirstOrDefault(professional => professional.Id == professionalId);
            var professionalName = professional.FullName;
            ViewBag.professionalName = professionalName;

            var dateStr = date;
            var dateTime = DateTime.ParseExact(dateStr, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            ViewBag.dateTime = dateTime;
            
            return View();
        }


        // POST: Turns/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> Create(Guid professionalId, Guid medicalServiceId, DateTime date, Turn turn)
        {
            TempData["medicalServiceId"] = medicalServiceId;
            TempData["professionalId"] = professionalId;
            TempData["date"] = date;


            var username = User.Identity.Name;
            var patient = _context.Patients.FirstOrDefault(patient => patient.Email == username);
            var patientId = patient.Id;

            

            if (ModelState.IsValid)
            {
                //Dato autogenerado
                turn.Id = Guid.NewGuid();
                turn.CreationDate = DateTime.Now;
                turn.Confirmed = false;
                turn.Active = true;
                turn.PatientId = patientId;
                turn.ProfessionalId = professionalId;
                turn.Date = date;
                //Agrego el dato a la base, de tipo Turn.
                _context.Add(turn);
                //Guardo los cambios
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MyTurns));
                
            }
                      
            return View();
        }
        
        
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CancelAdmin(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turn = await _context.Turns
                .Include(t => t.Patient)
                .Include(t => t.Professional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turn == null)
            {
                return NotFound();
            }
            return View(turn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CancelAdminConfirmed(Guid id, Turn turn, string description)
        {
            if (id != turn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var turnDatabase = _context.Turns.Find(id);

                    turnDatabase.Active = false;
                    turnDatabase.Confirmed = false;

                    if (!string.IsNullOrEmpty(description))
                    {
                        turnDatabase.CancelDescription = description;
                    }

                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnExists(turn.Id))
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
            return View(turn);
        }

        private bool ValidateCancel(Turn turn)
        {
            bool isValid = true;
            var result = turn.Date - DateTime.Now;
            if (result.TotalHours < 24)
            {
                isValid = false;
            }

            return isValid;
        }

        // GET: Turns/Delete/5
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> Cancel(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turn = await _context.Turns
                .Include(t => t.Patient)
                .Include(t => t.Professional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turn == null)
            {
                return NotFound();
            }

            if (!ValidateCancel(turn))
            {
                ModelState.AddModelError(nameof(Turn.Date), "No puede cancelar un turno con menos de 24 hs de anticipacion.");
            }

            return View(turn);
        }

        // POST: Turns/Delete/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> CancelConfirmed(Guid id)
        {
            var turn = await _context.Turns.FindAsync(id);

            if (ValidateCancel(turn))
            {
                _context.Turns.Remove(turn);
                await _context.SaveChangesAsync();
            } 

            return RedirectToAction(nameof(MyTurns));
        }

        private bool TurnExists(Guid id)
        {
            return _context.Turns.Any(e => e.Id == id);
        }


    }
}
