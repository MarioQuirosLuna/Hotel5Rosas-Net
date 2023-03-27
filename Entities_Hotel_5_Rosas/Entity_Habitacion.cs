using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{
    [Table("Habitacion", Schema = "HABITACION")]
    public class Entity_Habitacion
    {
        [Key]
        public int PK_Habitacion { get; set; }
        public int FK_Tipo_Habitacion { get; set; }
        public int FK_Hotel { get; set; }
        public int Numero_Habitacion { get; set; }
        public bool Estado { get; set; }
    }
}
