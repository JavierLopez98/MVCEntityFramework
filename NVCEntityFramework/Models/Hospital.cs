using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NVCEntityFramework.Models
{
    [Table("HOSPITAL")]
    public class Hospital
    {
        [Key]
        [Column("Hospital_cod")]
        public int idHospital { get; set; }
        [Column("Nombre")]
        public String Nombre { get; set; }
        [Column("Direccion")]
        public String Direccion { get; set; }
        [Column("Telefono")]
        public String Telefono { get; set; }
        [Column("Num_cama")]
        public int NumeroCamas { get; set; }
    }
}
