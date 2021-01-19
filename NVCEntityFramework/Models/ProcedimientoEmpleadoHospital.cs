using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Models
{
    public class ProcedimientoEmpleadoHospital
    {
        public List<EmpleadoHospital> empleados { get; set; }
        public int SumaSalarial { get; set; }
        public int MediaSalarial { get; set; }
    }
}
