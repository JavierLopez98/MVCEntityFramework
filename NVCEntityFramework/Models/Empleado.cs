using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Models
{
    [Table("EMP")]
    public class Empleado
    {
        [Key]
        [Column("Emp_no")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int empno { get; set; }
        public String Apellido { get; set; }
        public String Oficio { get; set; }
        public int Salario { get; set; }
        [Column("Dept_no")]
        public int departamento { get; set; }
    }
}
