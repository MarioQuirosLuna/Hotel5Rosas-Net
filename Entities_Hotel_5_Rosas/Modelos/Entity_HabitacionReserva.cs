using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas.Modelos
{
    public class Entity_HabitacionReserva
    {
        public int PK_habitacion { get; set; }
        public string Tipo_Habitacion { get; set; }
        public int Numero_Habitacion { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public decimal Tarifa { get; set; }
        public float Oferta { get; set; }
        public string Nombre_Temporada { get; set; }
    }
}
