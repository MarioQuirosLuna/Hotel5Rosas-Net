using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{

    [Table("Temporada", Schema = "OFERTA")]

    public class Entity_Temporada
    {

        [Key]
        public int PK_Temporada { get; set; }
        public string Nombre { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }

    }
}
