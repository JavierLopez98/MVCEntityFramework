using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Models
{
    public class ResumenDepartamento
    {
        public List<Empleado> empleados { get; set; }
        public int personas { get; set; }
        public int maxsalario { get; set; }
        public int minsalario { get; set; }
    }
}
