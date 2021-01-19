using NVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace NVCEntityFramework.Data
{
    public class DepartamentosContextMySql : IDepartamentosContext
    {
        private MySqlDataAdapter addept;
        private DataTable tabladept;

        public DepartamentosContextMySql(String cadena)
        {
            this.addept = new MySqlDataAdapter("Select * from dept", cadena);
            this.tabladept = new DataTable();
            this.addept.Fill(this.tabladept);
        }
        public List<Departamento> GetDepartamentos()
        {
            List<Departamento> departamentos = new List<Departamento>();
            var consulta = from datos in this.tabladept.AsEnumerable() select datos;
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
