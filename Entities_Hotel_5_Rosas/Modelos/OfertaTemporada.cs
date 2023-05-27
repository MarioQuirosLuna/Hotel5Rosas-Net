using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas.Modelos
{
    public class OfertaTemporada
    {

        public int PK_Oferta_Temporada { get; set; }
        public string Temporada { get; set; }
        public string Tipo_Habitacion { get; set; }
        public decimal Oferta { get; set; }

    }
}
