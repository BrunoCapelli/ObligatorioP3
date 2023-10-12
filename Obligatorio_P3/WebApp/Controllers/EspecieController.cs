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
        // protected IServicioAmenazas _servicioAmenazas;
        IWebHostEnvironment _webHostEnvironment { get; set; }

        public EspecieController(IServicioEspecie servicioEspecie, IServicioEstadoConservacion estadoConservacion, IWebHostEnvironment webHostEnvironment) 
        {
            _servicioEspecie = servicioEspecie;
            _servicioEstadoConservacion = estadoConservacion;
            _webHostEnvironment = webHostEnvironment;
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

        [HttpPost]
        public IActionResult Create(string NombreCientifico, string NombreVulgar, string Descripcion, string PesoMin, string PesoMax, int EstadoConservacion, IFormFile Imagen)
        {
            try
            {
                Double.TryParse(PesoMin, out double pesoMinParsed);
                Double.TryParse(PesoMax, out double pesoMaxParsed);

                EstadoConservacionDTO EstadoC = _servicioEstadoConservacion.GetEstado(EstadoConservacion);

                EspecieDTO newEspecie = new EspecieDTO(NombreCientifico, NombreVulgar, Descripcion, pesoMinParsed, pesoMaxParsed, EstadoC);

                if(newEspecie != null)
                {
                    _servicioEspecie.Add(newEspecie);

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
                        rutaRaiz = Path.Combine(rutaRaiz, "img", "ecosistemas");
                        string nuevoNombre = newEspecie.EspecieId.ToString() + "_001" + extension;
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
                }


                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }

            return View("Index");

        }

    }
}
