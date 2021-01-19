using Microsoft.AspNetCore.Mvc;
using NVCEntityFramework.Models;
using NVCEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Controllers
{
    public class TodosEmpleadosController : Controller
    {
        RepositoryTodosEmpleados repo;

        public TodosEmpleadosController(RepositoryTodosEmpleados repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<TodosEmpleados> empleados=this.repo.GetEmpleados();
            return View(empleados);
        }
        public IActionResult Buscador()
        {
            ViewData["Departamentos"] = this.repo.GetDepartamentos();
            return View();
        }
        [HttpPost]
        public IActionResult Buscador(String dep)
        {
            ViewData["Departamentos"] = this.repo.GetDepartamentos();
            ProcedimientoTodosEmpleados datos = this.repo.GetEmpleadosDepartamento(dep);
            return View(datos);
        }
    }
}
