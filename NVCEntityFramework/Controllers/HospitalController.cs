using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NVCEntityFramework.Repositories;
using NVCEntityFramework.Models;

namespace NVCEntityFramework.Controllers
{
    public class HospitalController : Controller
    {
        private RepositoryHospital repo;
        

        public HospitalController(RepositoryHospital repo)
        {
            this.repo = repo;
        }
        
        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repo.GetHospitals();
            return View(hospitales);
        }

        
    }
}
