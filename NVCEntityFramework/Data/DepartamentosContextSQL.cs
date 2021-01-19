using NVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NVCEntityFramework.Data
{
    public class DepartamentosContextSQL : IDepartamentosContext
    {

    
        private SqlDataAdapter addept;
        private DataTable tabladept;

        public DepartamentosContextSQL(String cadena)
        {
         //   String cadena = "Data Source=LOCALHOST;Initial Catalog=Hospital;Persist Security Info=True;User ID=SA;Password=MCSD2020";
            this.addept = new SqlDataAdapter("select * from dept", cadena);
            this.tabladept = new DataTable();
            this.addept.Fill(this.tabladept);
        }
        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.tabladept.AsEnumerable() select datos;
            List<Departamento> departamentos = new List<Departamento>();
            foreach(var row in consulta)
            {
                Departamento dept = new Departamento();
                dept.Numero = row.Field<int>("dept_no");
                dept.Nombre = row.Field<String>("Dnombre");
                dept.Localidad = row.Field<String>("Loc");
                departamentos.Add(dept);
            }
            return departamentos;
        }
    }
}
