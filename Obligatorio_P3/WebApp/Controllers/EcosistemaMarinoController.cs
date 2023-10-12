using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.IServicios;
using Servicios.Servicios;
using System.Collections.Generic;

namespace WebApp.Controllers {
    public class EcosistemaMarinoController : Controller {

        IServicioEcosistemaMarino _servicioEcosistemaMarino;
        IServicioPais _servicioPais;
        IServicioEstadoConservacion _servicioEstadoConservacion;
        IWebHostEnvironment _webHostEnvironment { get; set; }




        public EcosistemaMarinoController(IServicioEcosistemaMarino servicioEcosistemaMarino,IServicioPais servicioPais, IServicioEstadoConservacion servicioEstadoConservacion, IWebHostEnvironment webHostEnvironment) {
            _servicioEcosistemaMarino = servicioEcosistemaMarino;
            _servicioPais = servicioPais;
            _servicioEstadoConservacion = servicioEstadoConservacion;
            _webHostEnvironment = webHostEnvironment;
        }

        
        public ActionResult Index() {
            return View("Lista");
        }

        // GET: EcosistemaMarinoController/Create
        public ActionResult Create() {
            IEnumerable <EstadoConservacionDTO> estados= _servicioEstadoConservacion.GetAll();
            IEnumerable <PaisDTO> paises = _servicioPais.GetAll();

            ViewBag.estados = estados;
            ViewBag.paises = paises;
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(string Nombre, string Area, string Latitud, string Longitud ,string GradoPeligro,int Pais, int EstadoConservacion,IFormFile Imagen) {
            try 
            {
                Double.TryParse(Latitud, out double latitudParsed);
                Double.TryParse(Longitud, out double longitudParsed);
                Int32.TryParse(GradoPeligro, out int gradoPeligro);
                Double.TryParse(Area, out double areaParsed);
                //Int32.TryParse(EstadoConservacion, out int estConservacionParsed);
                
                

                UbiGeografica ubi = new UbiGeografica(latitudParsed,longitudParsed, gradoPeligro);
                //EstadoConservacionDTO newEstadoC = new EstadoConservacionDTO(estConservacionParsed);

                EstadoConservacionDTO EstadoC = _servicioEstadoConservacion.GetEstado(EstadoConservacion);
                

                EcosistemaMarinoDTO ecoDTO = new EcosistemaMarinoDTO(Nombre, ubi, areaParsed, EstadoC, Pais);
                EcosistemaMarinoDTO nuevoEco = _servicioEcosistemaMarino.Add(ecoDTO);

                // Aca hay que asignarle el Ecositema al Pais?

                string ArchivoName = Path.GetFileName(Imagen.FileName);
                //string fileName = Path.GetFileNameWithoutExtension(Imagen.FileName);
                string extension = Path.GetExtension(ArchivoName);

                if (extension != ".jpg" && extension !=".jpeg" && extension!= ".png") {
                    ViewBag.Msg = "Formatos de imagen admitidos: jpeg,jpg o png";
                    return View();
                }

                string rutaRaiz = _webHostEnvironment.WebRootPath;
                rutaRaiz = Path.Combine(rutaRaiz, "img","ecosistemas");
                string nuevoNombre = nuevoEco.EcosistemaMarinoId.ToString() + "_001" + extension;
                string ruta = Path.Combine(rutaRaiz, nuevoNombre);
                using (FileStream stream = new FileStream(ruta, FileMode.Create)) {
                    Imagen.CopyTo(stream);
                }
                ViewBag.Msg = "Ecosistema creado!";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) {
                IEnumerable<EstadoConservacionDTO> estados = _servicioEstadoConservacion.GetAll();
                IEnumerable<PaisDTO> paises = _servicioPais.GetAll();
                ViewBag.estados = estados;
                ViewBag.paises = paises;
                ViewBag.Msg = ex.Message;
                return View();
            }
        }
        /*
        // GET: EcosistemaMarinoController/Details/5
        public ActionResult Details(int id) {
            return View();
        }


        // GET: EcosistemaMarinoController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: EcosistemaMarinoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: EcosistemaMarinoController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: EcosistemaMarinoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
        */
    }
}
