using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{
    [Table("Facilidad", Schema = "HOTEL")]
    public class Entity_Facilidad
    {
        [Key]
        public int PK_Facilidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int FK_Imagen { get; set; }
        public int FK_Hotel { get; set; }

    }
}
