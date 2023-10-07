using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.IServicios;

namespace WebApp.Controllers {
    public class EcosistemaMarinoController : Controller {

        IServicioEcosistemaMarino _servicioEcosistemaMarino;

        public EcosistemaMarinoController(IServicioEcosistemaMarino servicioEcosistemaMarino) {
            _servicioEcosistemaMarino = servicioEcosistemaMarino;
        }
        // GET: EcosistemaMarinoController
        public ActionResult Index() {
            return View();
        }

        // GET: EcosistemaMarinoController/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: EcosistemaMarinoController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: EcosistemaMarinoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
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
    }
}
