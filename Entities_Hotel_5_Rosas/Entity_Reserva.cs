using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{
    [Table("Reserva", Schema = "HABITACION")]
    public class Entity_Reserva
    {
        [Key]
        public int PK_Reserva { get; set; }
        public int FK_Habitacion { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Apellidos_Cliente { get; set; }
        public string Numero_Tarjeta { get; set; }
        public string Correo { get; set; }

        public DateTime Fecha_Transaccion { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public decimal Tarifa_Total { get; set; }
    }
}
