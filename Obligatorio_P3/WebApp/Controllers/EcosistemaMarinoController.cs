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
            IEnumerable<EcosistemaMarinoDTO> ecos = _servicioEcosistemaMarino.GetAll();
            foreach(EcosistemaMarinoDTO e in ecos) {
                e.ImagenURL = ObtenerNombreImagen(e.EcosistemaMarinoId);
            }
            ViewBag.Ecosistema = ecos;

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            try {
                _servicioEcosistemaMarino.Remove(id);
                IEnumerable<EcosistemaMarinoDTO> ecos = _servicioEcosistemaMarino.GetAll();
                foreach (EcosistemaMarinoDTO e in ecos) {
                    e.ImagenURL = ObtenerNombreImagen(e.EcosistemaMarinoId);
                }
                ViewBag.Ecosistema = ecos;
                ViewBag.Msg = "El ecosistema ha sido eliminado con exito";


            }
            catch (Exception ex) {
                ViewBag.Msg = ex.Message;
                
            }

            return (View("Index"));

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
        public ActionResult Create(string Nombre, int Area, double Latitud, double Longitud ,int GradoPeligro,int Pais, int EstadoConservacion,IFormFile Imagen) {
            try 
            {
                
                UbiGeografica ubi = new UbiGeografica(Latitud, Longitud, GradoPeligro);
                ubi.Validate();

                EstadoConservacionDTO EstadoC = _servicioEstadoConservacion.GetEstado(EstadoConservacion);
                

                EcosistemaMarinoDTO ecoDTO = new EcosistemaMarinoDTO(Nombre, ubi, Area, EstadoC, Pais);
                EcosistemaMarinoDTO nuevoEco = _servicioEcosistemaMarino.Add(ecoDTO);


                string ArchivoName = Path.GetFileName(Imagen.FileName);
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




        public string ObtenerNombreImagen(int id) {
           
            // Construye el nombre del archivo de imagen en función del ID.
            string nombreArchivo = id + "_001";

            // Comprueba las extensiones posibles (jpg, jpeg, png) y obtén la ruta si existe.
            string[] extensiones = { "jpg", "jpeg", "png" };

            foreach (string extension in extensiones) {
                //string rutaImagen = Path.Combine(carpetaImagenes, nombreArchivo + "." + extension);
                //string rutaImagen = carpetaImagenes + "/" + nombreArchivo + "." + extension;
                string rutaImagen = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "img", "ecosistemas", nombreArchivo + "." + extension);

                if (System.IO.File.Exists(rutaImagen)) {
                    return nombreArchivo + "." + extension;
                }
            }

            // Devuelve una cadena vacía si la imagen no se encuentra.
            return string.Empty;
        }
    }
}
