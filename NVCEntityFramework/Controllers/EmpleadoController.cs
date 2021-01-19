using Microsoft.AspNetCore.Mvc;
using NVCEntityFramework.Models;
using NVCEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Controllers
{
    public class EmpleadoController : Controller
    {
        private RepositoryEmpleados repo;
        public EmpleadoController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            ViewData["oficios"] = this.repo.getOficios();
            List<Empleado> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }
        [HttpPost]
        public IActionResult Index(int incremento,String oficio)
        {
            ViewData["oficios"] = this.repo.getOficios();
            ViewData["seleccionado"] = oficio;
            List<Empleado> empleados = this.repo.GetEmpleadoOficio(oficio);
            this.repo.ModificarSalarios(incremento,oficio);
            return View(empleados);
        }
        public IActionResult EmpleadosDepartamentosLambda(int departamento)
        {
            ResumenDepartamento resumen = this.repo.GetResumenDepartamento(departamento);
            return View(resumen);
        }
    }
}
