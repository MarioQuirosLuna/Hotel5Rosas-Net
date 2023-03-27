using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{
    [Table("Tipo_Habitacion", Schema = "HABITACION")]
    public class Entity_TipoHabitacion
    {
        [Key]
        public int PK_Tipo_Habitacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Tarifa { get; set; }
    }
}
