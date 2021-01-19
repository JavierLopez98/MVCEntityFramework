using Microsoft.AspNetCore.Mvc;
using NVCEntityFramework.Models;
using NVCEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Controllers
{
    public class EmpleadosHospitalController : Controller
    {
        RepositoryEmpleadosHospital repo;
        public EmpleadosHospitalController(RepositoryEmpleadosHospital repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<EmpleadoHospital> empleados = this.repo.GetEmpleadoHospital();
            return View(empleados);
        }

        public IActionResult ProcedimientoEmpleadosHospital()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProcedimientoEmpleadosHospital(int hospitalcod)
        {
            ProcedimientoEmpleadoHospital datos = this.repo.GetEmpleadoHospital(hospitalcod);
            return View(datos);
        }
    }
}
