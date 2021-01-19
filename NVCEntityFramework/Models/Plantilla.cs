using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Models
{
    [Table("Plantilla")]
    public class Plantilla
    {
        [Key]
        [Column("Empleado_no")]
        public int codigo { get; set; }
        public String Apellido { get; set; }
        public String Funcion { get; set; }
        public int Salario { get; set; }
    }
}
