using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Models
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        [Column("Doctor_no")]
        public int IdDoctor { get; set; }
        public String Apellido { get; set; }
        public String Especialidad { get; set; }
        public int Salario { get; set; }
        [Column("Hospital_cod")]
        public int Hospital { get; set; }
    }
}
