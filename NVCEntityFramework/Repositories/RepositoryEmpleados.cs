using NVCEntityFramework.Data;
using NVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Repositories
{
    public class RepositoryEmpleados
    {

        public EmpleadoContext context;
        public RepositoryEmpleados(EmpleadoContext context)
        {
            this.context = context;
        }
        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados select datos;
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleadoOficio(String oficio)
        {
            var consulta = from datos in this.context.Empleados where datos.Oficio == oficio select datos;
            return consulta.ToList();
        }
        public List<String> getOficios()
        {
            var consulta = (from datos in this.context.Empleados select datos.Oficio).Distinct();
            return consulta.ToList();
        }
        public void ModificarSalarios(int incremento,String oficio)
        {
            List<Empleado> empleados = GetEmpleadoOficio(oficio);
            foreach(Empleado emple in empleados)
            {
                emple.Salario += incremento;
            }
            this.context.SaveChanges();

        }

        public ResumenDepartamento GetResumenDepartamento(int deptno)
        {
            List<Empleado> empleados = this.GetEmpleados();
            List<Empleado> filtro = empleados.Where(z => z.departamento == deptno).ToList();
            if (filtro.Count() == 0) return null;
            ResumenDepartamento resumen = new ResumenDepartamento();
            resumen.empleados = filtro;
            resumen.personas = filtro.Count();
            resumen.maxsalario = filtro.Max(z => z.Salario);
            resumen.minsalario = filtro.Min(z => z.Salario);

            return resumen;
        }
    }
}
