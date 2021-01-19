using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Models
{
    [Table("TodosEmpleados")]
    public class TodosEmpleados
    {
        [Key]
        public int Idempleado { get; set; }
        public String Apellido { get; set; }
        public String Oficio { get; set; }
        public int Salario { get; set; }
        public String Nombre { get; set; }
        
    }
}
