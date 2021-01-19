using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Models
{
    [Table("ENFERMO")]
    public class Enfermo
    {
        [Key]
        [Column("INSCRIPCION")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Inscripcion { get; set; }
        [Column("APELLIDO")]
        public String Apellido { get; set; }
        [Column("DIRECCION")]
        public String Direccion { get; set; }
        [Column("Fecha_Nac")]
        public DateTime FechaNacimiento { get; set; }
        [Column("S")]
        public String Genero { get; set; }
        [Column("NSS")]
        public String NSS { get; set; }
    }
}
