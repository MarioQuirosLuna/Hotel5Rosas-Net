using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{
    [Table("Correo", Schema = "HOTEL")]
    public class Entity_Correo
    {
        [Key]
        public int PK_Correo { get; set; }
        public string Correo { get; set; }
        public int FK_Hotel { get; set; }
    }
}
