﻿using Domain.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Servicios.IServicios;
using Servicios.Servicios;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class EspecieController : Controller
    {
        protected IServicioEspecie _servicioEspecie;
        protected IServicioEstadoConservacion _servicioEstadoConservacion;
        protected IServicioEcosistemaMarino _servicioEcosistemaMarino;
        protected IConfiguration _configuration;

        protected IServicioEcosistemaMarinoEspecie _servicioEcosistemaMarinoEspecie;

        IWebHostEnvironment _webHostEnvironment { get; set; }

        public EspecieController(IServicioEspecie servicioEspecie,
            IServicioEstadoConservacion estadoConservacion, 
            IServicioEcosistemaMarino servicioEcosistemaMarino,
            IWebHostEnvironment webHostEnvironment, 
            IConfiguration configuration,
            IServicioEcosistemaMarinoEspecie servicioEcosistemaMarinoEspecie) 
        {
            _servicioEspecie = servicioEspecie;
            _servicioEstadoConservacion = estadoConservacion;
            _servicioEcosistemaMarino = servicioEcosistemaMarino;
            _servicioEcosistemaMarinoEspecie = servicioEcosistemaMarinoEspecie;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ViewBag.Ecosistemas = _servicioEcosistemaMarino.GetAll();
            IEnumerable<EspecieDTO> especies = _servicioEspecie.GetAll();
            foreach (EspecieDTO e in especies) {
                e.ImagenURL = ObtenerNombreImagen(e.EspecieId);
            }

            ViewBag.Especies = especies;
            return View();
        }


        [HttpPost]
        public IActionResult Delete(int id) {
            if (HttpContext.Session.Get("email") != null) {
                try {
                    _servicioEspecie.Remove(id);
                    ViewBag.Ecosistemas = _servicioEcosistemaMarino.GetAll();
                    IEnumerable<EspecieDTO> especies = _servicioEspecie.GetAll();
                    foreach (EspecieDTO e in especies) {
                        e.ImagenURL = ObtenerNombreImagen(e.EspecieId);
                    }

                    ViewBag.Especies = especies;
                    ViewBag.Msg = "La especie ha sido eliminada con exito";
                    BorrarImagen(id);
                }
                catch (Exception ex) {
                    ViewBag.Msg = ex.Message;

                }


                return View("Index");
            }else {
                TempData["msg"] = "Debe iniciar sesion para realizar esa accion";
                return RedirectToAction("Login", "Usuario");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.Get("email") != null) {
                IEnumerable<EstadoConservacionDTO> estados = _servicioEstadoConservacion.GetAll();
                ViewBag.estados = estados;
                return View();
            }
            else {
                TempData["msg"] = "Debe iniciar sesion para realizar esa accion";
                return RedirectToAction("Login", "Usuario");
            }
            
        }

        [HttpPost]
        public IActionResult Create(string NombreCientifico, string NombreVulgar, string Descripcion, string PesoMin, string PesoMax, int EstadoConservacion, IFormFile Imagen)
        {
            ViewBag.Especies = _servicioEspecie.GetAll();
            ViewBag.Ecosistemas = _servicioEcosistemaMarino.GetAll();
            try
            {
                Double.TryParse(PesoMin, out double pesoMinParsed);
                Double.TryParse(PesoMax, out double pesoMaxParsed);

                EstadoConservacionDTO EstadoC = _servicioEstadoConservacion.GetEstado(EstadoConservacion);

                EspecieDTO newEspecie = new EspecieDTO(NombreCientifico, NombreVulgar, Descripcion, pesoMinParsed, pesoMaxParsed, EstadoC);
                newEspecie.NombreMin = extraerValor("ParametersTopes:NombreMin");
                newEspecie.NombreMax = extraerValor("ParametersTopes:NombreMax");
                newEspecie.DescripcionMin = extraerValor("ParametersTopes:DescripcionMin");
                newEspecie.DescripcionMax = extraerValor("ParametersTopes:DescripcionMax");

                
                EspecieDTO especieCreada = _servicioEspecie.Add(newEspecie);

                string ArchivoName = Path.GetFileName(Imagen.FileName);
                //string fileName = Path.GetFileNameWithoutExtension(Imagen.FileName);
                string extension = Path.GetExtension(ArchivoName);

                if(Imagen != null)
                {
                    if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                    {
                        ViewBag.Msg = "Formatos de imagen admitidos: jpeg,jpg o png";
                        return View();
                    }

                    string rutaRaiz = _webHostEnvironment.WebRootPath;
                    rutaRaiz = Path.Combine(rutaRaiz, "img", "especies");
                    string nuevoNombre = especieCreada.EspecieId.ToString() + "_001" + extension;
                    string ruta = Path.Combine(rutaRaiz, nuevoNombre);
                    using (FileStream stream = new FileStream(ruta, FileMode.Create))
                    {
                        Imagen.CopyTo(stream);
                    }

                    ViewBag.Msg = "Especie creada!";
                }
                else
                {
                    throw new Exception("La imagen ingresada no es valida");
                }
                
                

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Msg = ex.Message;
                IEnumerable<EstadoConservacionDTO> estados = _servicioEstadoConservacion.GetAll();
                ViewBag.estados = estados;

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
                string rutaImagen = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "img", "especies", nombreArchivo + "." + extension);

                if (System.IO.File.Exists(rutaImagen)) {
                    return nombreArchivo + "." + extension;
                }
            }

            // Devuelve una cadena vacía si la imagen no se encuentra.
            return string.Empty;
        }

        private int extraerValor(string clave) {
            int valor = 0;
            string strValor = _configuration[clave];
            Int32.TryParse(strValor, out valor);
            return valor;
        }

        public void BorrarImagen(int id) {
            // Construye el nombre del archivo de imagen en función del ID.
            string nombreArchivo = id + "_001";

            // Comprueba las extensiones posibles (jpg, jpeg, png) y obtén la ruta si existe.
            string[] extensiones = { "jpg", "jpeg", "png" };

            foreach (string extension in extensiones) {
                //string rutaImagen = Path.Combine(carpetaImagenes, nombreArchivo + "." + extension);
                //string rutaImagen = carpetaImagenes + "/" + nombreArchivo + "." + extension;
                string rutaImagen = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "img", "especies", nombreArchivo + "." + extension);

                if (System.IO.File.Exists(rutaImagen)) {
                    System.IO.File.Delete(rutaImagen);
                }
            }


        }

        [HttpGet]
        public IActionResult Asignar()
        {
            ViewBag.Ecosistemas = _servicioEcosistemaMarino.GetAll();
            ViewBag.Especies = _servicioEspecie.GetAll();


            return View();
        }

        [HttpPost]
        public IActionResult Asignar(int EspecieId, int EcosistemaId)
        {
            try
            {
                if (EcosistemaId != 0 && EspecieId != 0 && _servicioEcosistemaMarinoEspecie.isApto(EspecieId, EcosistemaId))
                {

                    _servicioEcosistemaMarinoEspecie.Add(EcosistemaId, EspecieId);
                }
                
                return RedirectToAction("Index");

            }catch(Exception ec)
            {
                
                TempData["msg"] = ec.Message;
                return RedirectToAction("Asignar");
            }

        }

        [HttpPost]
        public IActionResult FiltrarPorNombreCientifico(string fNombreCientifico)
        {
            ViewBag.Especies = _servicioEspecie.FiltrarPorNombreCientifico(fNombreCientifico);
            return View("Index");
        }

        
    }
}
