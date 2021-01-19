using Microsoft.EntityFrameworkCore;
using NVCEntityFramework.Data;
using NVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

#region procesos/vista
//alter view todosempleados
//as
//select emp_no as idempleado, apellido, oficio, salario, dept.DNOMBRE as nombre from emp inner join Dept on emp.DEPT_NO=dept.DEPT_NO
//union
//select Doctor_no as idempleado, APELLIDO, ESPECIALIDAD, salario, nombre as nombre from doctor inner join HOSPITAL on doctor.HOSPITAL_COD=Hospital.HOSPITAL_COD
//union
//select EMPLEADO_NO as idempleado, APELLIDO, FUNCION, SALARIO, Nombre as nombre from PLANTILLA inner join HOSPITAL on plantilla.HOSPITAL_COD=hospital.HOSPITAL_COD
//go

//alter procedure getEmpledoNombre(@Nombre nvarchar, @suma int, @media int)
//as
//select* from todosempleados
//select @suma = sum(salario),@media = avg(salario) from todosempleado where Nombre = @Nombre
//go

//create procedure distintosdepartamentos
//as
//select distinct  nombre from todosempleados
//go

#endregion

namespace NVCEntityFramework.Repositories
{
    public class RepositoryTodosEmpleados
    {
        TodosEmpleadosContext context;
        public RepositoryTodosEmpleados(TodosEmpleadosContext context)
        {
            this.context = context;
        }

        public List<TodosEmpleados> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados select datos;
            return consulta.ToList();

        }

        public List<String> GetDepartamentos()
        {
            using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                List<String> Departamentos = new List<String>();
                String Sql = "distintosdepartamentos";
                com.CommandText = Sql;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Connection.Open();
                DbDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Departamentos.Add(reader["Nombre"].ToString());
                }
                com.Connection.Close();
                return Departamentos;
            }
        }

        public ProcedimientoTodosEmpleados GetEmpleadosDepartamento(String nombre)
        {
            //getEmpledoNombre(@codigo int,@suma int,@media int)
            String sql = "getEmpledoNombre @Nombre, @suma out, @media out";
            SqlParameter pamnombre = new SqlParameter("@Nombre", nombre);
            SqlParameter pamsuma = new SqlParameter("@suma", -1);
            pamsuma.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pammedia = new SqlParameter("@media", -1);
            pammedia.Direction = System.Data.ParameterDirection.Output;
            List<TodosEmpleados> empleados = this.context.Empleados.FromSqlRaw(sql, pamnombre, pamsuma, pammedia).ToList() ;
            ProcedimientoTodosEmpleados salida = new ProcedimientoTodosEmpleados();
            salida.Empleados = empleados;
            if (!(pamsuma.Value is DBNull))
                salida.SumaSalarial = Convert.ToInt32(pamsuma.Value);
            else salida.SumaSalarial = 0;
            if (!(pammedia.Value is DBNull))
                salida.MediaSalarial = Convert.ToInt32(pammedia.Value);
            else salida.MediaSalarial = 0;
            
            return salida;
        }
    }
}
