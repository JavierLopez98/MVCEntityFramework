using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Models
{
    public class ResumenPlantilla
    {
        public List<Plantilla> plantilla { get; set; }
        public int Personas { get; set; }
        public int MaxSalario { get; set; }
        public int MinSalario { get; set; }
    }
}
