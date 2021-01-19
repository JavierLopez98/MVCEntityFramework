using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NVCEntityFramework.Data;
using NVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;


#region procesos

//create procedure mostrarDoctoresEspecialidad(@especialidad nvarchar(30))
//as
//select* from DOCTOR where ESPECIALIDAD = @especialidad
//go


//create procedure mostrarEspecialidades 
//as
//select distinct especialidad from doctor
//go


//create procedure modificarSalarioEspecialidad(@salario int, @especialidad nvarchar(30))
//as
//update doctor set SALARIO=@salario where ESPECIALIDAD=@especialidad
//go

#endregion


namespace NVCEntityFramework.Repositories
{
    public class RepositoryDoctores
    {
        HospitalContext context;

        public RepositoryDoctores(HospitalContext context)
        {
            this.context = context;
        }

        public void UpdateEspecialidad(int iddoctor,String esp)
        {
            this.context.ModificarEspecialidad(iddoctor,esp);
        }

        public List<Doctor> GetDoctores()
        {
            String sql = "mostrarDoctores";
            List<Doctor> doctores = this.context.Doctores.FromSqlRaw(sql).ToList() ;
            return doctores;
        }

        public void ModificarSalarioEspecialidad(int salario, String esp)
        {
            String sql = "modificarSalarioEspecialidad @salario,@especialidad";
            SqlParameter paramsal = new SqlParameter("@salario", salario);
            SqlParameter paramesp = new SqlParameter("@especialidad", esp);
            this.context.Database.ExecuteSqlRaw(sql, paramsal, paramesp);
        }

        public List<Doctor> GetDoctoresEspecialidad(String esp)
        {
            String sql = "mostrarDoctoresEspecialidad @especialidad";
            SqlParameter pamesp = new SqlParameter("@especialidad", esp);
            List<Doctor> doctores = this.context.Doctores.FromSqlRaw(sql, pamesp).ToList();
            return doctores;
        }

        

        public List<String> GetEspecialidades()
        {
            using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                String sql = "mostrarEspecialidades";
                com.CommandText = sql;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Connection.Open();
                DbDataReader reader = com.ExecuteReader();
                List<String> especialidades = new List<String>();
                while (reader.Read())
                {
                    especialidades.Add(reader["Especialidad"].ToString());
                }
                com.Connection.Close();
                return especialidades;
            }
        }

        public List<String> GetEspecialidadesLinq()
        {
            String sql = "mostrarDoctores";
            List<String> especialidades = new List<String>();
            List<Doctor> doctores = this.context.Doctores.FromSqlRaw(sql).ToList();
            foreach(Doctor doc in doctores)
            {
                if (!especialidades.Contains(doc.Especialidad)) especialidades.Add(doc.Especialidad);
            }

            return especialidades;
        }
    }
}
