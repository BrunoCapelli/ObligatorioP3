using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Servicios.IServicios;
using Servicios.Servicios;

namespace WebApp.Controllers
{
    public class EspecieController : Controller
    {
        protected IServicioEspecie _servicioEspecie;
        protected IServicioEstadoConservacion _servicioEstadoConservacion;
       // protected IServicioAmenazas _servicioAmenazas;
        public EspecieController(IServicioEspecie servicioEspecie, IServicioEstadoConservacion estadoConservacion) 
        {
            _servicioEspecie = servicioEspecie;
            _servicioEstadoConservacion = estadoConservacion;
        }
        public IActionResult Index()
        {

            ViewBag.Especies = _servicioEspecie.GetAll(); 
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<EstadoConservacionDTO> estados = _servicioEstadoConservacion.GetAll();
            ViewBag.estados = estados;
            return View();
        }

    }
}
