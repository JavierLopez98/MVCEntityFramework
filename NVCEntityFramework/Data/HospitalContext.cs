using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

#region procesos
//create procedure mostrarDoctores
//as
//	select * from DOCTOR
//go

//create procedure cambiarEspecialidad(@iddoctor int, @especialidad nvarchar(30))
//as
//update doctor set ESPECIALIDAD=@especialidad where DOCTOR_NO=@iddoctor
//go

//alter view empleadoshospital
//as
//select isnull(empleado_no,0)as IdEmpleado,apellido,funcion,salario,hospital_cod from plantilla
//union
//select doctor_no, apellido, especialidad, salario, hospital_cod from DOCTOR
//go

//create procedure proceempleadoshospital(@hospitalcod int, @suma int out, @media int out)
//as
//select* from empleadoshospital where hospital_cod = @hospitalcod
//        select @suma = sum(salario),@media = avg(salario) from empleadoshospital where hospital_cod = @hospitalcod
//go
#endregion

namespace NVCEntityFramework.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options): base(options)
        {

        }

        public DbSet<Hospital> hospitales { get; set; }

        public DbSet<Plantilla> plantilla { get; set; }

        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<EmpleadoHospital> EmpleadosHospital { get; set; }

        //[NotMapped]
        //public DbSet<Doctor> Especialidades { get; set; }

        //Primer procedimiento de Accion

        public void ModificarEspecialidad(int iddoctor,String esp)
        {
            String sql = "cambiarEspecialidad @iddoctor, @especialidad";

            SqlParameter pamid = new SqlParameter("@iddoctor", iddoctor);
            SqlParameter pamesp = new SqlParameter("@especialidad", esp);
            this.Database.ExecuteSqlRaw(sql,pamid,pamesp);
        }
        

        //public List<String> mostrarEspecialidades()
        //{
        //    String sql = "mostrarEspecialidades";
        //    List<String> Especialidades = 
        //    return Especialidades;
        //}
    }
}
