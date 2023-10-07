using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.IServicios;

namespace WebApp.Controllers {
    public class EcosistemaMarinoController : Controller {

        IServicioEcosistemaMarino _servicioEcosistemaMarino;
       

        public EcosistemaMarinoController(IServicioEcosistemaMarino servicioEcosistemaMarino) {
            _servicioEcosistemaMarino = servicioEcosistemaMarino;
        }

        
        public ActionResult Index() {
            return View("Lista");
        }

        // GET: EcosistemaMarinoController/Create
        public ActionResult Create() {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(string Nombre, string Area, string Latitud, string Longitud ,string GradoPeligro) {
            try 
            {
                Double.TryParse(Latitud, out double latitudParsed);
                Double.TryParse(Longitud, out double longitudParsed);
                int.TryParse(GradoPeligro, out int gradoPeligro);

                UbiGeografica ubi = new UbiGeografica(latitudParsed,longitudParsed, gradoPeligro);
                
                EstadoConservacionDTO newEstadoC = new EstadoConservacionDTO();
                Double.TryParse(Area, out double areaPArsed);

                EcosistemaMarinoDTO ecoDTO = new EcosistemaMarinoDTO(Nombre, ubi, areaPArsed, newEstadoC);
                _servicioEcosistemaMarino.Add(ecoDTO);
                ViewBag.Msg = "Ecosistema creado!";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) {
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
