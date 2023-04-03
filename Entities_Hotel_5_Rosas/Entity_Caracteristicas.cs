using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{
    [Table("Caracteristicas", Schema = "HABITACION")]
    public class Entity_Caracteristicas
    {
        [Key]
        public int PK_Caracteristicas { get; set; }
        public string Nombre { get; set; }
    }
}
