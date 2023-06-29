using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{

    [Table("Imagen", Schema = "PAGINA")]

    public class Entity_Imagen
    {

        [Key]
        public int PK_Imagen { get; set; }
        public string Imagen { get; set; }
        public int FK_Galeria { get; set; }
        public bool show { get; set; }

    }
}
