using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{
    [Table("Galeria", Schema = "PAGINA")]

    public class Entity_Galeria
    {

        [Key]
        public int PK_Galeria { get; set; }
        public int FK_Pagina { get; set; }

    }
}
