using Microsoft.AspNetCore.Mvc;
using NVCEntityFramework.Models;
using NVCEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Controllers
{
    public class EnfermosController : Controller
    {
        private RepositoryEnfermos repo;
        public EnfermosController(RepositoryEnfermos repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Enfermo> enfermos = this.repo.GetEnfermos();
            return View(enfermos);
        }
        public IActionResult detalles(int inscripcion)
        {
            Enfermo enf = this.repo.BuscarEnfermo(inscripcion);
            return View(enf);
        }

        public IActionResult EnfermosGenero(String genero)
        {
            List<Genero> generos = this.repo.GetGeneros();
            ViewData["Generos"]=generos;
            if (genero != null)
            {
                List<Enfermo> enfermos = this.repo.GetEnfermosGenero(genero);
                return View(enfermos);
            }else return View();
        }

        public IActionResult EliminarEnfermo(int inscripcion)
        {
            this.repo.EliminarEnfermo(inscripcion);
            return RedirectToAction("Index");
        }

        public IActionResult InsertarEnfermo()
        {
            List<Genero> generos = this.repo.GetGeneros();
            return View(generos);
        }
        [HttpPost]
        public IActionResult InsertarEnfermo(Enfermo enf)
        {
            this.repo.InsertarEnfermo(enf.Inscripcion, enf.Apellido, enf.Direccion, enf.FechaNacimiento, enf.Genero, enf.NSS);
            return RedirectToAction("Index");
        }

        public IActionResult ModificarEnfermo(int inscripcion)
        {
            ViewData["generos"] = this.repo.GetGeneros();
            Enfermo enf = this.repo.BuscarEnfermo(inscripcion);
            return View(enf);
        }
        [HttpPost]
        public IActionResult ModificarEnfermo(Enfermo enf)
        {
            this.repo.ModificarEnfermo(enf.Inscripcion, enf.Apellido, enf.Direccion, enf.FechaNacimiento, enf.Genero, enf.NSS);
            return RedirectToAction("Index");
        }
    }
}
