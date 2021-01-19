using Microsoft.AspNetCore.Mvc;
using NVCEntityFramework.Models;
using NVCEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Controllers
{
    public class PlantillaController : Controller
    {
        private RepositoryPlantilla repo;

        public PlantillaController(RepositoryPlantilla repo)
        {
            this.repo = repo;
        }
        public IActionResult ResumenPlantilla(int salario)
        {
            ResumenPlantilla resumen = this.repo.GetResumenPlantilla(salario);
            return View(resumen);
        }
    }
}
