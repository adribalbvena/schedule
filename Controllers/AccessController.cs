using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using tp_nt1.Database;
using tp_nt1.Extensions;
using tp_nt1.Models;

namespace tp_nt1.Controllers
{
    [AllowAnonymous]
    public class AccessController : Controller
    {
        private readonly ScheduleDbContext _context;
        private const string _Return_Url = "ReturnUrl";

        public AccessController(ScheduleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Patient patient, string pass)
        {
            try
            {
                pass.ValidatePassword();
            }
            catch (Exception e)
            {
                ModelState.AddModelError(nameof(Patient.Password), e.Message);
            }

            if (_context.Patients.Any(pat => pat.Email == patient.Email))
            {
                ModelState.AddModelError(nameof(Patient.Email), "El email ya se encuentra utilizado");
            }

            if (ModelState.IsValid)
            {
                patient.Id = Guid.NewGuid();
                patient.Password = pass.Encrypt();
                _context.Add(patient);
                _context.SaveChanges();
                return RedirectToAction(nameof(Login));
            }
            return View(patient);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            //Guardamos la url de retorno para que una vez concluido el login de usuario
            //lo podamos redirigir a la pagina en la que se encontraba antes
            TempData[_Return_Url] = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password, Role role)
        {
            string returnUrl = TempData[_Return_Url] as string;

            if(!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                User user = null;

                if (role == Role.Profesional)
                {
                    user = _context.Professionals.FirstOrDefault(professional => professional.Email == username);
                } else if (role == Role.Paciente)
                {
                    user = _context.Patients.FirstOrDefault(patient => patient.Email == username);
                } else if (role == Role.Administrador)
                {
                    user = _context.Admins.FirstOrDefault(admin => admin.Email == username);
                }

                if (user != null) 
                {
                    var encryptedPassword = password.Encrypt();

                    if(user.Password.SequenceEqual(encryptedPassword))
                    {

                        // Se crean las credenciales del usuario que serán incorporadas al contexto
                        ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                        // El lo que luego obtendré al acceder a User.Identity.Name
                        identity.AddClaim(new Claim(ClaimTypes.Name, username));

                        // Se utilizará para la autorización por roles
                        identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));

                        // Lo utilizaremos para acceder al Id del usuario que se encuentra en el sistema.
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

                        // Lo utilizaremos cuando querramos mostrar el nombre del usuario logueado en el sistema.
                        identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));
                        identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));
                        identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                        // En este paso se hace el login del usuario al sistema
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

                        TempData["LoggedIn"] = true;

                        if (!string.IsNullOrWhiteSpace(returnUrl))
                            return Redirect(returnUrl);

                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                }
            }

            // Completo estos dos campos para poder retornar a la vista en caso de errores.
            ViewBag.Error = "Usuario o contraseña incorrectos";
            ViewBag.Username = username;
            TempData[_Return_Url] = returnUrl;

            return View();

        }

        [Authorize]
        [HttpPost]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        [Authorize]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
