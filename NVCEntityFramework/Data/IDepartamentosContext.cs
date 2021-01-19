using NVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Data
{
    public interface IDepartamentosContext
    {
        List<Departamento> GetDepartamentos();
    }
}
