using Microsoft.AspNetCore.Mvc;
using Servicios.IServicios;

namespace WebApp.Controllers
{
    public class EspecieController : Controller
    {
        protected IServicioEspecie _servicioEspecie;
        public EspecieController(IServicioEspecie servicioEspecie) 
        {
            _servicioEspecie = servicioEspecie;
        }
        public IActionResult Index()
        {

            ViewBag.Especies = _servicioEspecie.GetAll(); 
            return View();
        }

    }
}
