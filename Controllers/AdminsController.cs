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
    [Authorize(Roles = "Administrador")]
    public class AdminsController : Controller
    {
        private readonly ScheduleDbContext _context;

        public AdminsController(ScheduleDbContext context)
        {
            _context = context;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Admins.ToListAsync());
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Admin admin, string pass)
        {
            try
            {
                pass.ValidatePassword();
            }
            catch (Exception e)
            {
                ModelState.AddModelError(nameof(Admin.Password), e.Message);
            }

            if (_context.Admins.Any(administrator => administrator.Email == admin.Email))
            {
                ModelState.AddModelError(nameof(Admin.Email), "El email ya se encuentra utilizado");
            }

            if (ModelState.IsValid)
            {
                admin.Id = Guid.NewGuid();
                admin.CreationDate = DateTime.Now;
                admin.Password = pass.Encrypt();
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Admin admin, string pass)
        {
            if (!string.IsNullOrEmpty(pass))
            {
                try
                {
                    pass.ValidatePassword();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(nameof(Admin.Password), e.Message);
                }
            }

            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var adminDatabase = _context.Admins.Find(id);

                    adminDatabase.FirstName = admin.FirstName;
                    adminDatabase.LastName = admin.LastName;
                    adminDatabase.Address = admin.Address;
                    adminDatabase.Email = admin.Email;


                    if (!string.IsNullOrEmpty(pass))
                    {
                        adminDatabase.Password = pass.Encrypt();
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Id))
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
            return View(admin);
        }


        private bool AdminExists(Guid id)
        {
            return _context.Admins.Any(e => e.Id == id);
        }
    }
}
