using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{

    [Table("Publicidad", Schema = "PUBLICIDAD")]

    public class Entity_Publicidad
    {
        [Key]
        public int PK_Publicidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int FK_Imagen { get; set; }
        public int FK_Hotel { get; set; }
        public string Imagen { get; set; }

    }
}
