using Microsoft.AspNetCore.Mvc;
using NVCEntityFramework.Models;
using NVCEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Controllers
{
    public class DoctoresController : Controller
    {
        RepositoryDoctores repo;
        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateDoctoresEspecialidad()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }
        [HttpPost]
        public IActionResult UpdateDoctoresEspecialidad(int iddoctor,String esp)
        {
            this.repo.UpdateEspecialidad(iddoctor, esp);
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        public IActionResult UpdateSalarioEspecialidad()
        {
            ViewData["especialidades"] = this.repo.GetEspecialidades();
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }
        [HttpPost]
        public IActionResult UpdateSalarioEspecialidad(int salario,String esp)
        {
            this.repo.ModificarSalarioEspecialidad(salario, esp);
            List<Doctor> doctores = this.repo.GetDoctoresEspecialidad(esp);
            ViewData["especialidades"] = this.repo.GetEspecialidades();
            return View(doctores);
        }
    }
}
