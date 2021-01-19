using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NVCEntityFramework.Data;
using NVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Repositories
{
    public class RepositoryEmpleadosHospital
    {
        HospitalContext context;
        public RepositoryEmpleadosHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<EmpleadoHospital> GetEmpleadoHospital()
        {
            var consulta = from datos in this.context.EmpleadosHospital select datos;
            return consulta.ToList();
        }
        public ProcedimientoEmpleadoHospital GetEmpleadoHospital(int Hospitalcod)
        {
            String sql = "proceempleadoshospital @hospitalcod,@suma out,@media out";
            SqlParameter pamcodigo = new SqlParameter("@hospitalcod", Hospitalcod);
            SqlParameter pamsuma = new SqlParameter("@suma", -1);
            pamsuma.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pammedia = new SqlParameter("@media", -1);
            pammedia.Direction = System.Data.ParameterDirection.Output;
            List<EmpleadoHospital> empleados = this.context.EmpleadosHospital.FromSqlRaw(sql,pamcodigo,pamsuma,pammedia).ToList();
            ProcedimientoEmpleadoHospital salida = new ProcedimientoEmpleadoHospital();
            salida.empleados = empleados;
            salida.SumaSalarial = Convert.ToInt32(pamsuma.Value);
            salida.MediaSalarial = Convert.ToInt32(pammedia.Value);

            return salida;

        }
    }
}
