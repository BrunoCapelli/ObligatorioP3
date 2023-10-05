using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.IServicios;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        protected IServicioUsuario _servicioUsuario;
        public UsuarioController(IServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }
        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Register y Login al sistema
        [HttpGet]
        public IActionResult LogIn() 
        {
            return View();        
        }
        /*
        [HttpPost]
        public IActionResult Login(string user, string password)
        {
            if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(password))
            {
                UsuarioDTO userLogged = _servicioUsuario.Find(user, password);
                if(userLogged != null)
                {
                    HttpContext.Session.SetString("email", userLogged.Alias);

                }
                else
                {
                    ViewBag.DatosErroneos = "Los datos son incorrectos";
                    return View();
                }
                return View();
            }
            else
            {
                ViewBag.DatosErroneos = "Debe completar los campos";
                return View();
            }
        }
        */
       
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
    }
}
