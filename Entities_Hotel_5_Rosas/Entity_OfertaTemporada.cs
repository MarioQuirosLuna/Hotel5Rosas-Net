using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{
    [Table("Oferta_Temporada", Schema = "OFERTA")]
    public class Entity_OfertaTemporada
    {
        [Key]
        public int PK_Oferta_Temporada { get; set; }
        public int FK_Temporada { get; set; }
        public int FK_Tipo_Habitacion { get; set; }
        public int Oferta { get; set; }
    }
}
