using NVCEntityFramework.Data;
using NVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Repositories
{
    public class RepositoryPlantilla
    {
        private HospitalContext context; 

        public RepositoryPlantilla(HospitalContext context)
        {
            this.context = context;
        }
        public List<Plantilla> GetPlantillas()
        {
            var consulta = from datos in this.context.plantilla select datos;
            return consulta.ToList();
        }
        public ResumenPlantilla GetResumenPlantilla(int salario)
        {
            var consulta = from datos in this.context.plantilla where datos.Salario >= salario select datos;
            if (consulta.Count() == 0) return null;
            ResumenPlantilla resumen = new ResumenPlantilla();
            resumen.plantilla = consulta.ToList();
            resumen.Personas = consulta.Count();
            resumen.MaxSalario = consulta.Max(z => z.Salario);
            resumen.MinSalario = consulta.Min(z => z.Salario);
            return resumen;
        }
    }
}
