using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{

    [Table("Pagina", Schema = "PAGINA")]

    public class Entity_Pagina
    {

        [Key]
        public int PK_Pagina { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string Informacion { get; set; }
        public int FK_Hotel { get; set; }


    }
}
