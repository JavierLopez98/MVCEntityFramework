using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Models
{
    [Table("EmpleadosHospital")]
    public class EmpleadoHospital
    {
        [Key]
        public int IdEmpleado { get; set; }
        public String Apellido { get; set; }
        public String Funcion { get; set; }
        public int Salario { get; set; }

        [Column("Hospital_cod")]
        public int Hospital { get; set; }
    }
}
